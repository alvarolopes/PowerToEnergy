using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Ajax.Utilities;

namespace MvcApplication2.Models
{
    public class PowerReadings
    {
        public PowerReadings(string readings)
        {
            if (readings.IsNullOrWhiteSpace())
                throw new ArgumentException("Invalid Power Readings.");

            PowerReadingList = new List<PowerRead>();

            using (var reader = new StringReader(readings))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.IsNullOrWhiteSpace())
                        continue;

                    PowerReadingList.Add(new PowerRead(line));
                }
            }
        }

        public IList<PowerRead> PowerReadingList { get; private set; }

        public string ToEnergy()
        {
            var interval = new TimeSpan(0, 15, 0); // 15 minutes.
            var sb = new StringBuilder();

            var groupedTimes = from dt in PowerReadingList
                group dt by dt.Date.Ticks/interval.Ticks
                into g
                select
                    new
                    {
                        Begin = new DateTime(g.Key*interval.Ticks),
                        End = new DateTime(g.Key*interval.Ticks).AddMinutes(15),
                        Kilowatts = g.Sum(o => o.Kilowatts)
                    };

            foreach (var value in groupedTimes)
            {
                sb.AppendLine(string.Format("{0} {1} {2}",
                    UnixTimestampFromDateTime(value.Begin),
                    UnixTimestampFromDateTime(value.End),
                    ConvertPowerToEnergy(value.Kilowatts, interval)));
            }


            return sb.ToString();
        }

        private Decimal ConvertPowerToEnergy(Decimal kilowatts, TimeSpan interval)
        {
            return kilowatts*(Convert.ToDecimal(interval.Minutes)/60M);
        }

        private long UnixTimestampFromDateTime(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }
    }
}
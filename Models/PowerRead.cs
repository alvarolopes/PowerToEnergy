using System;
using System.Globalization;
using Microsoft.Ajax.Utilities;

namespace MvcApplication2.Models
{
    public class PowerRead
    {
        public PowerRead(string line)
        {
            if (line.IsNullOrWhiteSpace())
                throw new ArgumentException("Invalid Power Read.");

            string strDate = line.Substring(0, 19);
            var dtfi = new DateTimeFormatInfo();
            dtfi.ShortDatePattern = "dd/MM/yyyy hh24:mi:ss";
            dtfi.DateSeparator = "/";
            dtfi.TimeSeparator = ":";

            Date = Convert.ToDateTime(strDate, dtfi);

            Watts = Convert.ToDecimal(line.Substring(20).Trim());
        }

        public DateTime Date { get; private set; }
        public Decimal Watts { get; private set; }

        public Decimal Kilowatts
        {
            get { return Convert.ToDecimal(Watts/1000M); }
        }
    }
}
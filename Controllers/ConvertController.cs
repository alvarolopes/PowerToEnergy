using System;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class ConvertController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.energyReadings = string.Empty;

            return View();
        }

        public ActionResult ConvertPowerToEnergy(string readings)
        {
            if (readings.IsNullOrWhiteSpace())
                throw new ArgumentException("Invalid Power Readings.");

            ViewBag.energyReadings = new PowerReadings(readings).ToEnergy();

            return View("Index");
        }
    }
}
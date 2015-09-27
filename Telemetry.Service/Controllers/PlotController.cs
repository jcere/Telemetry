using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Telemetry.Service.Controllers
{
    public class PlotController : Controller
    {
        // GET: Plot
        public ActionResult Index()
        {
            return View();
        }
    }
}
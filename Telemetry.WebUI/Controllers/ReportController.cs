using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Telemetry.WebUI.Models;

namespace Telemetry.WebUI.Controllers
{

    public class ReportController : Controller
    {

        public ReportController()
        {
            // service connection
            this.ViewData["serviceUrl"] = Properties.Settings.Default.ServiceUrl;
        }


        // GET: index
        public ActionResult Index()
        {
            return View();
        }

    }
}

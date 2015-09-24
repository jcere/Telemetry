using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

//using Telemetry.WebUI.ViewModels;


namespace Telemetry.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get()
        {
            // TODO: request actual data from web api GET

            return Json("stuff", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Plot()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";                                                    

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
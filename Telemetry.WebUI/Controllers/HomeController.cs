using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

using Telemetry.WebUI.ViewModels;


namespace Telemetry.WebUI.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            // TODO: request actual data from web api GET

            Temp temp = new Temp(3, 4, 1);
            temp.Data = new List<double>() 
            { 
                3, 6, 2, 7, 5, 2, 0, 3, 8, 9, 2, 5, 9, 3, 6, 3, 6, 2, 7, 5, 2, 1, 3, 8, 9,                                             
                2, 5, 9, 2, 7 
            };
            return Json(temp, JsonRequestBehavior.AllowGet);
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
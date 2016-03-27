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

        // GET: Plot/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plot/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plot/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Plot/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Plot/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Plot/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

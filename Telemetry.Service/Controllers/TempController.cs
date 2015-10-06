using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Telemetry.Service.DAL.Interfaces;
using Telemetry.Service.ViewModels;

namespace Telemetry.Service.Controllers
{
    /// <summary>
    /// temperature data controller
    /// </summary>
    public class TempController : ApiController
    {

        private TempViewModel model;
        private IDataInterface tempRepo;

        /// <summary>
        /// public constructor for temperature data 
        /// </summary>
        /// <param name="tempRepo">accepts temperature repository</param>
        public TempController(IDataInterface tempRepo)
        {
            this.tempRepo = tempRepo;
        }

        // GET api/<controller>
        /// <summary>
        /// simple get all data from temperature table
        /// </summary>
        /// <returns>JsonResult containing view model</returns>
        public JsonResult Get()
        {
            model = new TempViewModel(tempRepo.GetData());
            return GetJsonResult(model);
        }

        // GET api/<controller>?<time=''>&<span=''>
        /// <summary>
        /// get temperature data starting at time and continuing for a number of samples
        /// </summary>
        /// <param name="time">time in seconds</param>
        /// <param name="samples">number of samples</param>
        /// <returns>JsonResult containing view model</returns>
        public JsonResult Get(double time, int samples)
        {
            model = new TempViewModel(tempRepo.GetSamplesFrom(time, samples));
            return GetJsonResult(model);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private JsonResult GetJsonResult(TempViewModel model)
        {

            JsonResult res = new JsonResult();
            res.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            res.Data = model;
            return res;
        }

    }
}

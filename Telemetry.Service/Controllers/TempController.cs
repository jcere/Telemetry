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
    public class TempController : ApiController
    {

        private TempViewModel model;
        private IDataInterface tempRepo;

        public TempController(IDataInterface tempRepo)
        {
            this.tempRepo = tempRepo;
        }

        // GET api/<controller>
        public JsonResult Get()
        {
            model = new TempViewModel(tempRepo.GetData());
            return GetJsonResult(model);
        }

        // GET api/<controller>/<time>:<span>
        public JsonResult Get(double time, int numSamples)
        {
            model = new TempViewModel(tempRepo.GetSamplesFrom(time, numSamples));
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


// GET api/<controller>
//public Models.TempViewModel GetModel()
//{
//    model = new Models.TempViewModel();
//    var data = temp.GetData();
//    foreach (var item in data)
//    {
//        model.Data.Add(new Models.TempSample(item.Time, item.TempC));
//    }
//    return model;
//}

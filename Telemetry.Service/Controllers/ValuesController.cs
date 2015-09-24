using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.Controllers
{
    public class ValuesController : ApiController
    {

        private Models.TempViewModel model;
        private ITempRepo temp;

        public ValuesController()
        {
            model = new Models.TempViewModel();
            temp = new DAL.Managers.TempRepo();
        }

        // GET api/<controller>
        public Models.TempViewModel Get()
        {
            model = new Models.TempViewModel();
            var data = temp.GetData();
            foreach (var item in data)
            {
                model.Data.Add(new Models.TempSample(item.Time, item.TempC));
            }
            return model;
        }

        public JsonResult GetJson()
        {
            // TODO: request actual data from web api GET
            model = new Models.TempViewModel();
            var data = temp.GetData();
            foreach (var item in data)
            {
                model.Data.Add(new Models.TempSample(item.Time, item.TempC));
            }
            JsonResult res = new JsonResult();
            res.Data = model;
            return res;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
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
    }
}
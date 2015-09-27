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
            temp = new DAL.Managers.TempRepo();
        }

        // GET api/<controller>
        public JsonResult Get()
        {
            model = new Models.TempViewModel(temp.GetData());
            MyJsonResult res = new MyJsonResult(model);
            return res;
        }

        // GET api/<controller>/<time>:<span>
        public string Get(double time, double span)
        {
            model = new Models.TempViewModel(temp.GetSpan(time, span));
            MyJsonResult res = new MyJsonResult(model);
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

        public class MyJsonResult : JsonResult
        {
            public MyJsonResult(object data)
            {
                this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                this.Data = data;
            }
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

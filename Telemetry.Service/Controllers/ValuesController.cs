using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.Controllers
{
    public class ValuesController : ApiController
    {

        private ITempRepo temp;

        public ValuesController()
        {
            temp = new DAL.TempRepo();
        }

        // GET api/<controller>
        public IEnumerable<DAL.Entities.Temp> Get()
        {
            List<DAL.Entities.Temp> data = temp.GetData();
            return data;
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
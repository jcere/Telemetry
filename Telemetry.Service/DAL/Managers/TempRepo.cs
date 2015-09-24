using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Service.DAL.Models;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.DAL.Managers
{

    /// <summary>
    /// process temperature data, conversions, formating, queries with time windows
    /// </summary>
    public class TempRepo : ITempRepo
    {
        private TempContext db;

        public TempRepo()
        {
            db = new TempContext();
        }

        // extract all temperature data
        public List<Temperature> GetData()
        {
            return db.Temps.ToList();
        }

        // extract temperature data in given window


        // convert to fahrenheit
        // TODO: what else would we want to see?
    }


}

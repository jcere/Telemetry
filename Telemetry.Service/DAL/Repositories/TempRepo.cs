using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Service.DAL.Entities;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.DAL
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

        // extract specific time window
        public List<Temp> GetData()
        {
            return db.Temps.ToList();
        }

        // convert to celcius
        private double ConvertToCelcius(double calvin)
        {
            return calvin - 273.15;
        }

        // convert to fahrenheit


        // TODO: what else would we want to see?

    }
}

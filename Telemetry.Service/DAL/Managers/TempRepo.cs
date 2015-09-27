using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Telemetry.Service.DAL.Models;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.DAL.Managers
{

    /// <summary>
    /// process temperature data, conversions, formating, queries with time windows
    /// </summary>
    public class TempRepo : ITempRepo
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        public List<Temperature> GetSpan(double time, double span)
        {
            double upper = time + span / 2.0;
            double lower = time - span / 2.0;
            var filtered = db.Temps.Where(s => s.Time < upper).Where(s => s.Time > lower);
            return filtered.ToList();
        }


        // convert to fahrenheit
        // TODO: what else would we want to see?
    }


}

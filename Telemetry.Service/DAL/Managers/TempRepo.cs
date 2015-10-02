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
    public class TempRepository : IDataInterface
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private TempContext db;

        public TempRepository()
        {
            db = new TempContext();
        }

        // extract all temperature data
        public List<Temperature> GetData()
        {
            return db.Temps.ToList();
        }

        // extract given number of samples starting at time
        public List<Temperature> GetSamplesFrom(double time, int samples)
        {
            int plusMinus = samples / 2;
            var filtered = db
                .Temps.Where(s => s.Time > time).OrderBy(s => s.Time).Take(samples);
            return filtered.ToList();
        }

        // TODO: data validation - find gaps


        // convert to fahrenheit


        // TODO: what other sorts of reports would we like to see?
    }


}

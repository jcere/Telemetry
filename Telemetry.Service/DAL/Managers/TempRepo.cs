using System.Collections.Generic;
using System.Linq;
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

        private ITimeDomainContext db;

        public TempRepository()
        {
            this.db = new TempContext();
        }

        /// <summary>
        /// extract all data fron db temp table
        /// </summary>
        public List<Temperature> GetData()
        {
            return db.Temps.ToList();
        }

        /// <summary>
        ///  extract given number of samples starting at time
        /// </summary>
        public List<Temperature> GetSamplesFrom(double time, int samples)
        {
            // get data for period following time, return num samples following
            var filtered = db
                .Temps.Where(s => s.Time > time).OrderBy(s => s.Time).Take(samples);

            return filtered.ToList();
        }

        // TODO: data validation - check for gaps, check for noise

        // TODO: what other sorts of reports would we like to see?
    }


}

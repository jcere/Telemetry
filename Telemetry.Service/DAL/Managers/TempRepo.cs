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
            List<Temperature> collected = null;
            try
            {
                collected = db.Temps.ToList();
            }
            catch (Exception ex)
            {
                log.Debug(ex);
            }
            return collected;
        }

        // extract temperature data in given window


        // convert to fahrenheit
        // TODO: what else would we want to see?
    }


}

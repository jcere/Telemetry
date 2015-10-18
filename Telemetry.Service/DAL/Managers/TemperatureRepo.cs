using System.Collections.Generic;
using System.Linq;
using Telemetry.Service.DAL.Models;
using Telemetry.Service.DAL.Interfaces;
using System;
using System.Data.Entity.Infrastructure;

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

        private TelemetryContext db;
        private const string WebConfigKey = "TempFilePath";

        public TempRepository()
        {
            this.db = new TelemetryContext();
        }

        /// <summary>
        /// extract all data fron db temp table
        /// </summary>
        public List<Temperature> GetData()
        {
            return db.Temperatures.ToList();
        }

        /// <summary>
        ///  extract given number of samples starting at time
        /// </summary>
        public List<Temperature> GetSamplesFrom(double time, int samples)
        {
            // get data for period following time, return num samples following
            var filtered = db
                .Temperatures.Where(s => s.Time > time).OrderBy(s => s.Time).Take(samples);

            return filtered.ToList();
        }

        /// <summary>
        /// get samples given time span, start time, and sample period
        /// </summary>
        public List<Temperature> GetSamplesFromSpan(double time, double span, int period)
        {
            List<Temperature> data = new List<Temperature>();
            // get data for period following time, return num samples following
            var filtered = db.Temperatures
                .Where(s => s.Time > time)
                .Where(s => s.Time <= (time + span))
                .OrderBy(s => s.Time).ToList();

            for (int i = 0; i < filtered.Count(); i += period)
            {
                data.Add(filtered[i]);
            }
            return data;
        }

        /// <summary>
        /// write temperature data to DbSet then save
        /// </summary>
        public bool AddDataToDb(List<Temperature> data)
        {
            try
            {
                foreach (var item in data)
                {
                    db.Temperatures.Add(item);
                }
                db.SaveChanges();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                log.Debug(ex);
                return false;
            }
        }

        // TODO: what other sorts of reports would we like to see?

        // TODO: data validation - check for gaps, check for noise

        /// <summary>
        /// parse temperature data from csv array
        /// </summary>
        public List<Temperature> ParseTemperatureDataFile()
        {
            List<Temperature> data = new List<Temperature>();
            string filePath = null; // GetAppSettingFromSiteWebConfig(WebConfigKey);
            filePath = "E:\\Temp\\vdv.csv";

            string[] rawData = Tools.ReadFileIntoArray(filePath);
            foreach (var item in rawData)
            {
                string[] splitzed = item.Split(',');
                Temperature temp = new Temperature();
                temp.TempID = Convert.ToInt32(splitzed[0]);
                temp.Time = Convert.ToDouble(splitzed[1]);
                temp.Level = Convert.ToInt32(splitzed[2]);
                temp.Volt = Convert.ToDouble(splitzed[3]);
                temp.TempC = Convert.ToDouble(splitzed[4]);
                temp.DateTime = splitzed[5];
                data.Add(temp);
            }
            return data;
        }

        /// <summary>
        /// retrieve a setting by name from the route web configuration file
        /// </summary>
        public string GetAppSettingFromSiteWebConfig(string name)
        {
            System.Configuration.Configuration webConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

            if (webConfig.AppSettings.Settings.Count > 0)
            {
                System.Configuration.KeyValueConfigurationElement customSetting =
                    webConfig.AppSettings.Settings[name];

                return customSetting.Value;
            }
            return null;
        }
    }
}

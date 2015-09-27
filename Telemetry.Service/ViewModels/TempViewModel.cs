using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.Models
{
    /// <summary>
    /// temperature data presentation view model
    /// </summary>
    public class TempViewModel
    {

        public TempViewModel(List<Temperature> collection)
        {
            this.Data = new List<TempSample>();
            foreach (var item in collection)
            {
                this.Data.Add(new Models.TempSample(item.Time, item.TempC));
            }
        }

        /// <summary>
        /// temperature plot data
        /// </summary>
        public List<TempSample> Data { get; set; }

    }

    public class TempSample
    {
        private string localTime;
         
        public TempSample(double time, double tempC)
        {
            Time = time;
            TempC = tempC;
            SetLocalTime();
        }

        public double Time { get; set; }
        public string DateTime { get { return localTime; } }
        public double TempC { get; set; }

        private void SetLocalTime()
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(Time);

            localTime = dateTime.ToLocalTime().ToLongTimeString();
        }
    }
}
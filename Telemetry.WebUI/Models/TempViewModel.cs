using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telemetry.WebUI.Models
{
    /// <summary>
    /// temperature data presentation view model
    /// </summary>
    public class TempSample
    {
        private string localTime;
         
        public TempSample() { }

        public TempSample(int id, double time, double tempC)
        {
            Id = id;
            Time = time;
            TempC = tempC;
            SetLocalTime();
        }

        public int Id { get; set; }
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
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

        public TempViewModel()
        {
            Data = new List<TempSample>();

        }

        /// <summary>
        /// temperature plot data
        /// </summary>
        public List<TempSample> Data { get; set; }

    }

    public class TempSample
    {
        public TempSample(double time, double tempC)
        {
            Time = time;
            TempC = tempC;
        }

        public double Time { get; set; }
        public double TempC { get; set; }

    }
}
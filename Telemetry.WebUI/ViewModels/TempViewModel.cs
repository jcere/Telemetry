using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.DAL.Entities;

namespace Telemetry.WebUI.ViewModels
{
    /// <summary>
    /// temperature data presentation view model
    /// </summary>
    public class Temp
    {

        public Temp(int start, int span, int freq)
        {
            Start = start;
            Span = span;
            Frequency = freq;
        }

        /// <summary>
        /// data stream
        /// </summary>
        public IEnumerable<double> Data { get; set; }

        /// <summary>
        /// start time stamp
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// number of samples
        /// </summary>
        public int Span { get; set; }

        /// <summary>
        /// samples per second
        /// </summary>
        public int Frequency { get; set; }
    }
}
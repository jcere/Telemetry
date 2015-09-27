using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL.Interfaces
{
    public interface ITempRepo
    {
        /// <summary>
        /// retieve all temperature data from database
        /// </summary>
        /// <returns>list of temperature records</returns>
        List<Temperature> GetData();
        /// <summary>
        /// retrieve temperature data given span of time and center point
        /// </summary>
        /// <param name="time">midpoint time</param>
        /// <param name="span">length of time window</param>
        /// <returns>list of temperature records</returns>
        List<Temperature> GetSpan(double time, double span);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL.Interfaces
{
    public interface IDataInterface
    {
        /// <summary>
        /// retieve all temperature data from database
        /// </summary>
        /// <returns>list of temperature records</returns>
        List<Temperature> GetData();

        /// <summary>
        /// extract given number of samples starting at time
        /// </summary>
        /// <param name="time">beginning or period of interest</param>
        /// <param name="samples">number of samples</param>
        /// <returns>list of temperature records</returns>
        List<Temperature> GetSamplesFrom(double time, int samples);
    }
}

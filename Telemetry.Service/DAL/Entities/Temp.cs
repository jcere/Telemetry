using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry.Service.DAL.Entities
{

    /// <summary>
    /// temperature telemetry from sensors
    /// </summary>
    public class Temp
    {

        public int ID { get; set; }
        public int Time { get; set; }
        public double Calvin { get; set; }

    }
}

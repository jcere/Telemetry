using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemetry.Service.DAL.Models
{

    /// <summary>
    /// temperature telemetry from sensors
    /// </summary>
    public class Temperature
    {

        [Key]
        public int ID { get; set; }
        public double Time { get; set; }
        public int Level { get; set; }
        public double Volt { get; set; }
        public double TempC { get; set; }
        public string DateTime { get; set; }

        [NotMapped]
        public double TempK { get { return this.TempC + 273.15; } }

    }
}

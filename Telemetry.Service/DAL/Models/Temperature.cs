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

        public int Id { get; set; }
        public int RemoteId { get; set; }
        public double Time { get; set; }
        public int Level { get; set; }
        public double Volt { get; set; }
        public double TempC { get; set; }
        public string DateTime { get; set; }

        [NotMapped]
        public double TempK { get { return this.TempC + 273.15; } }

        /// <summary>
        /// check if this is duplicate record
        /// </summary>
        public bool IsDuplicate(Temperature temp)
        {
            // TODO: checking duplicate data, may want to add some factors
            //if (CompareTimeStamp(temp)) return true;
            if (this.RemoteId == temp.RemoteId) return true;
            return false;
        }

        private bool CompareTimeStamp(Temperature temp)
        {
            var myTime = Math.Round(this.Time, 2);
            var theirTime = Math.Round(temp.Time, 2);
            if (myTime == theirTime)
                return true;
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Service.DAL.Entities;

namespace Telemetry.Service.DAL.Interfaces
{
    public interface ITempRepo
    {

        List<Temp> GetData();
    }
}

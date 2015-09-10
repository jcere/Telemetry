using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Telemetry.Service.DAL.Entities;

namespace Telemetry.Service.DAL
{

    /// <summary>
    /// simulate temperature data for testing
    /// </summary>
    public class TempDataInitializer : DropCreateDatabaseAlways<TempContext>
    {
        protected override void Seed(TempContext context)
        {

            var temps = new List<Temp>
            {
                new Temp{ ID=1, Time=1, Calvin=272.11 },
                new Temp{ ID=2, Time=2, Calvin=272.12 },
                new Temp{ ID=3, Time=3, Calvin=272.13 },
                new Temp{ ID=4, Time=4, Calvin=272.14 },
                new Temp{ ID=5, Time=5, Calvin=272.15 },
                new Temp{ ID=6, Time=6, Calvin=272.14 },
                new Temp{ ID=7, Time=7, Calvin=272.13 },
            };
            temps.ForEach(s => context.Temps.Add(s));
            context.SaveChanges();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL
{

    /// <summary>
    /// simulate temperature data for testing
    /// </summary>
    public class TempDataInitializer : DropCreateDatabaseAlways<TempContext>
    {
        protected override void Seed(TempContext context)
        {

            var temps = new List<Temperature>();
            temps.Add(new Temperature { ID = 1, Time = 1, TempC = 272.11, DateTime = "DT", Level = 1, Volt = 1.5 });
            temps.Add(new Temperature{ ID=2, Time=2, TempC=272.12, DateTime="DT", Level=1, Volt=1.5 });
            temps.Add(new Temperature{ ID=3, Time=3, TempC=272.13, DateTime="DT", Level=1, Volt=1.5 });
            temps.Add(new Temperature{ ID=4, Time=4, TempC=272.14, DateTime="DT", Level=1, Volt=1.5 });

            //temps.ForEach(s => context.Temps.Add(s));
            foreach (var item in temps)
            {
                context.Temps.Add(item);
            }

            context.SaveChanges();

        }
    }
}

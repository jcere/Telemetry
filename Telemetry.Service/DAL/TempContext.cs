using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemetry.Service.DAL.Entities;

namespace Telemetry.Service.DAL
{

    /// <summary>
    /// database context for temperature data
    /// </summary>
    public class TempContext : DbContext
    {

        public TempContext()
            : base()
        {
        }

        public DbSet<Temp> Temps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TempContext>(new TempDataInitializer());
        }


    }
}

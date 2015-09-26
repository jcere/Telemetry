using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL
{

    /// <summary>
    /// database context for temperature data
    /// </summary>
    public class TempContext : DbContext
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public TempContext()
            : base()
        {
            bool dbExists = this.Database.Exists();
            if(!dbExists)
            {
                log.Debug("no connection to db");
            }
        }

        public DbSet<Temperature> Temps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer<TempContext>(new TempDataInitializer());
            // Database does not pluralize table names
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory("name=TempContext"));
            // Turn off the Migrations, (NOT a code first Db)
            SetDatabaseInitializer<TempContext>(null);
        }
    }
}

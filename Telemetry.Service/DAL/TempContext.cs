using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL
{

    /// <summary>
    /// database context for temperature data
    /// </summary>
    public class TempContext : DbContext, ITimeDomainContext
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public TempContext() : base() { }

        public DbSet<Temperature> Temps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class MyDbConfiguration : DbConfiguration
    {
        /// <summary>
        /// my db configuration from web.config
        /// </summary>
        public MyDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory("name=TempContext"));
            // Turn off the Migrations, (NOT a code first Db)
            SetDatabaseInitializer<TempContext>(null);
        }
    }
}

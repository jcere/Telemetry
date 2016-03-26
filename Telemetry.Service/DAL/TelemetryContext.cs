using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.DAL
{

    /// <summary>
    /// database context for temperature data
    /// </summary>
    public class TelemetryContext : DbContext, ITimeDomainContext
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public TelemetryContext() : base() { }

        public DbSet<Temperature> Temperatures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database does not pluralize table names
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class MyDbConfiguration : DbConfiguration
    {

        /// <summary>
        /// my db configuration from web.config
        /// </summary>
        public MyDbConfiguration()
        {
            SetDefaultConnectionFactory(new SqlConnectionFactory("name=TelemetryContext"));
            // Turn off the Migrations, (NOT a code first Db)
            SetDatabaseInitializer<TelemetryContext>(null);
        }
    }
}


/// <summary>
/// database context for temperature data
/// </summary>
//public class TempContext : DbContext, ITimeDomainContext
//{
//    // interface for debug logging
//    public static readonly log4net.ILog log = log4net.LogManager
//        .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


//    public TempContext() : base() { }

//    public DbSet<Temperature> Temperatures { get; set; }

//    protected override void OnModelCreating(DbModelBuilder modelBuilder)
//    {
//        // Database does not pluralize table names
//        // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//    }

//}

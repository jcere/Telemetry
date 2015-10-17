using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Web.Http;
using Telemetry.Service.DAL.Interfaces;
using Telemetry.Service.DAL.Managers;

namespace Telemetry.Service.Infrastructure
{
    public class BootStrapper
    {
        /// <summary>
        /// container is available for tests 
        /// </summary>
        public static IUnityContainer Container;

        public static void Initialize()
        {

            Logger.StartDebugLogging("TelemetryService");

            // start dependency injection
            Container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(Container);

        }

        /// <summary>
        /// build container and complete registering components
        /// </summary>
        /// <returns>container interface</returns>
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // Add ioc registration logic
            var myAssemblies = AppDomain
                .CurrentDomain
                .GetAssemblies().Where(a => a.FullName.StartsWith("Telemetry")).ToArray();

            System.Data.DataTable table = System.Data.Common.DbProviderFactories.GetFactoryClasses();

            // it is not necessary to register controllers
            container.RegisterType<IDataInterface, TempRepository>();

            return container;
        }
    }
}
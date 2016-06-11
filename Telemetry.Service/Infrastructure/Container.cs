using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.DAL.Interfaces;
using Telemetry.Service.DAL.Repositories;

namespace Telemetry.Service.Infrastructure
{
    public class Container
    {

        private static IUnityContainer container;
        public static IUnityContainer Instance
        {
            get
            {
                if (container == null) container = new UnityContainer();
                return container;
            }
        }

        /// <summary>
        /// build container and complete registering components
        /// </summary>
        /// <returns>container interface</returns>
        public static void Build()
        {
            // Add ioc registration logic
            var myAssemblies = AppDomain
                .CurrentDomain
                .GetAssemblies().Where(a => a.FullName.StartsWith("Telemetry")).ToArray();

            System.Data.DataTable table =
                System.Data.Common.DbProviderFactories.GetFactoryClasses();

            // it is not necessary to register controllers
            Instance.RegisterType<IDataInterface, TempRepository>();
            Instance.RegisterType<IConfig, DAL.FtpConfiguration>();

        }
    }
}
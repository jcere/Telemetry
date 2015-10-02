using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.Controllers;
using Telemetry.Service.DAL;
using Telemetry.Service.DAL.Interfaces;
using Telemetry.Service.DAL.Managers;

namespace Telemetry.Service.Infrastructure
{
    public class BootStrapper
    {
        public static UnityContainer Container;

        public static void Initialize()
        {
            Logger.StartDebugLogging("TelemetryService");
            Container = new UnityContainer();
            BootStrapper.RegisterTypes(Container);
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // Add ioc registration logic
            var myAssemblies = AppDomain
                .CurrentDomain
                .GetAssemblies().Where(a => a.FullName.StartsWith("Telemetry")).ToArray();

            container.RegisterType<IDataInterface, TempRepository>();
        }
    }
}
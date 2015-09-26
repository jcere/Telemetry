using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.DAL;

namespace Telemetry.Service.Infrastructure
{
    public class BootStrapper
    {
        public static void Initialize()
        {
            Logger.StartDebugLogging("TelemetryService");
            var container = new UnityContainer();
            BootStrapper.RegisterTypes(container);
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            // TODO: use ioc container
            // Add registration logic here
            var myAssemblies = 
                AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Telemetry")).ToArray();

            //container.RegisterTypes(
            //     UnityHelpers.GetTypesWithCustomAttribute<LifecycleSingletonAttribute>(myAssemblies),
            //     WithMappings.FromMatchingInterface,
            //     WithName.Default,
            //     WithLifetime.ContainerControlled,
            //     null
            //    ).RegisterTypes(
            //            UnityHelpers.GetTypesWithCustomAttribute<LifecycleTransientAttribute>(myAssemblies),
            //            WithMappings.FromMatchingInterface,
            //            WithName.Default,
            //            WithLifetime.Transient);

            //container.RegisterType(typeof(TempContext));
        }
    }
}
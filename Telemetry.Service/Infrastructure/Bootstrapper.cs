using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Web.Http;
using Telemetry.Service.DAL.Interfaces;
using Telemetry.Service.DAL.Repositories;

namespace Telemetry.Service.Infrastructure
{
    public class BootStrapper
    {

        public static void Initialize()
        {

            Logger.StartDebugLogging("TelemetryService");

            Container.Build();

            // start dependency injection and register
            GlobalConfiguration.Configuration.DependencyResolver = 
                new UnityResolver(Container.Instance);

        }
    }
}
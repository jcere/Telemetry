using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.Unity;
using Telemetry.Service.DAL.Interfaces;
using Telemetry.Service.DAL.Managers;
using Telemetry.WebUI.Controllers;
using System.Web.Mvc;
using Telemetry.Service.DAL;

namespace Telemetry.WebUI.Infrastructure
{
    public class ContainerBootstrapper
    {
      
        public static void Initialize()
        {
            var container = new UnityContainer();
            ContainerBootstrapper.RegisterTypes(container);
        }

        private static void RegisterTypes(IUnityContainer container)
        {

            container.RegisterType<ITempRepo, TempRepo>("Temperature");
            //container.RegisterType<IController, TempController>("Temperature");

        }

    }
}
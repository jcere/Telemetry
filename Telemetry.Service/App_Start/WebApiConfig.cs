using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Telemetry.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // enable cross domain 
            config.EnableCors();

            // Web API configuration and services
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TimeSpanApi",
                routeTemplate: "api/{controller}/{action}/{time}/{samples}",
                defaults: new { controller = "temp", action = "get" }
            );
        }
    }
}

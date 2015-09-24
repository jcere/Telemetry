using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telemetry.Service.Infrastructure
{
    public class BootStrapper
    {
        public static void Initialize()
        {
            Logger.StartDebugLogging("TelemetryService");
        }
    }
}
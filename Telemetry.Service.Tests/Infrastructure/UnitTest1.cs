using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.Infrastructure;

namespace Telemetry.Service.Tests.Infrastructure
{
    [TestClass]
    public class DependencyInjection
    {
        [TestMethod]
        public void InitializeUnity()
        {

            BootStrapper.Initialize();


        }
    }
}

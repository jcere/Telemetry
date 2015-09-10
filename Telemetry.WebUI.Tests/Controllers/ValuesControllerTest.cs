using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.WebUI.ViewModels;
using Telemetry.Service.Controllers;
using System.Collections.Generic;

namespace Telemetry.WebUI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void GetAllTempData()
        {
            var testData = GetTestData();
            var controller = new ValuesController();

            var result = controller.Get() as List<Temp>;
            Assert.AreEqual(testData.Count, result.Count);


        }

        public List<Temp> GetTestData()
        {
            var temps = new List<Temp>();
            //{
            //    new Temp( ID=1, Time=1, Calvin=272.11 },
            //    new Temp{ ID=2, Time=2, Calvin=272.12 },
            //    new Temp{ ID=3, Time=3, Calvin=272.13 },
            //    new Temp{ ID=4, Time=4, Calvin=272.14 },
            //    new Temp{ ID=5, Time=5, Calvin=272.15 },
            //    new Temp{ ID=6, Time=6, Calvin=272.14 },
            //    new Temp{ ID=7, Time=7, Calvin=272.13 },
            //};
            return temps;
        }

    }
}

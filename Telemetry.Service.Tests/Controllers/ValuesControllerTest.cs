using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Telemetry.WebUI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void GetTempDataFromLocalDB()
        {
            var controller = new ValuesController();
            var temperatures = controller.Get();

            Assert.IsNotNull(temperatures);
            Service.Models.TempViewModel model = temperatures.Data as Service.Models.TempViewModel;

            // local db only has 4 samples
            Assert.AreEqual(model.Data.Count, 4);                                                                                   
        }

        [TestMethod]
        public void GetTempDataFromRemoteDB()
        {
            var controller = new ValuesController();
            var temperatures = controller.Get();

            Assert.IsNotNull(temperatures);
            Service.Models.TempViewModel model = temperatures.Data as Service.Models.TempViewModel;

            // local db only has 4 samples
            Assert.AreNotEqual(model.Data.Count, 4);
        }

        [TestMethod]
        public void GetAllDataInJSON()
        {
            var controller = new ValuesController();
            JsonResult jsonResult = controller.Get();
            Assert.IsNotNull(jsonResult);

            Service.Models.TempViewModel model = jsonResult.Data as Service.Models.TempViewModel;
            Assert.IsNotNull(model);
        }
    }
}

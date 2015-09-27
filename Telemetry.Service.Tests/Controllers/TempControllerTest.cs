using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.Controllers;
using Telemetry.Service.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Telemetry.WebUI.Tests.Controllers
{
    [TestClass]
    public class TempControllerTest
    {
        [TestMethod]
        public void GetTempDataFromLocalDB()
        {
            var controller = new TempController();
            var temperatures = controller.Get();

            Assert.IsNotNull(temperatures);
            TempViewModel model = temperatures.Data as TempViewModel;

            // local db only has 4 samples
            Assert.AreEqual(model.Data.Count, 4);                                                                                   
        }

        [TestMethod]
        public void GetTempDataFromRemoteDB()
        {
            var controller = new TempController();
            var temperatures = controller.Get();

            Assert.IsNotNull(temperatures);
            TempViewModel model = temperatures.Data as TempViewModel;

            // local db only has 4 samples
            Assert.AreNotEqual(model.Data.Count, 4);
        }

        [TestMethod]
        public void GetAllDataInJSON()
        {
            var controller = new TempController();
            JsonResult jsonResult = controller.Get();
            Assert.IsNotNull(jsonResult);

            TempViewModel model = jsonResult.Data as TempViewModel;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetSpanDataInJSON()
        {
            var controller = new TempController();
            // taking 5 hour span - time in seconds - +/- 2.5 = 5 samples
            JsonResult jsonResult = controller.Get(1443250801.95, 18000.0);
            Assert.IsNotNull(jsonResult);

            TempViewModel model = jsonResult.Data as TempViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Data.Count, 5);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.Controllers;
using Telemetry.Service.ViewModels;
using Telemetry.Service.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Http;
using Microsoft.Practices.Unity;
using System.Web;

namespace Telemetry.WebUI.Tests.Controllers
{
    [TestClass]
    public class TempControllerTest
    {

        [TestMethod]
        public void GetTempDataFromRemoteDB()
        {
            //var controller = new TempController();
            BootStrapper.Initialize();
            var controller = BootStrapper.Container.Resolve<TempController>();
            var temperatures = controller.Get();

            Assert.IsNotNull(temperatures);
            TempViewModel model = temperatures.Data as TempViewModel;

            // local db only has 4 samples
            Assert.AreNotEqual(model.Data.Count, 4);
        }

        [TestMethod]
        public void GetAllDataInJSON()
        {
            BootStrapper.Initialize();
            var controller = BootStrapper.Container.Resolve<TempController>();

            JsonResult jsonResult = controller.Get();
            Assert.IsNotNull(jsonResult);

            TempViewModel model = jsonResult.Data as TempViewModel;
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetSpanDataInJSON()
        {
            BootStrapper.Initialize();
            var controller = BootStrapper.Container.Resolve<TempController>();
            // taking 5 hour span - time in seconds - +/- 2.5 = 5 samples
            JsonResult jsonResult = controller.Get(1443250801.95, 24);
            Assert.IsNotNull(jsonResult);

            TempViewModel model = jsonResult.Data as TempViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Data.Count, 24);
        }

        [TestMethod]
        public void GetDataDescriptors()
        {
            BootStrapper.Initialize();
            var controller = BootStrapper.Container.Resolve<TempController>();

            // taking 5 hour span - time in seconds - +/- 2.5 = 5 samples
            JsonResult jsonResult = controller.Get(1443250801.95, 24);
            Assert.IsNotNull(jsonResult);

            TempViewModel model = jsonResult.Data as TempViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Data.Count, 24);
        }
    }
}

﻿using System;
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
        public void GetTempDataFromDB()
        {
            var controller = new ValuesController();
            var temperatures = controller.Get();
            Assert.IsNotNull(temperatures);                                                                                    
        }

        [TestMethod]
        public void GetAllDataInJSON()
        {
            var controller = new ValuesController();
            JsonResult jsonResult = controller.GetJson();
            Assert.IsNotNull(jsonResult);

            Service.Models.TempViewModel model = jsonResult.Data as Service.Models.TempViewModel;
            Assert.IsNotNull(model);
        }
    }
}

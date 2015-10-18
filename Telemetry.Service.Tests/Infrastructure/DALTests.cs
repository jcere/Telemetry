using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.DAL.Managers;

namespace Telemetry.Service.Tests.Infrastructure
{
    [TestClass]
    public class DALTests
    {
        [TestMethod]
        public void ParseTextData()
        {
            TempRepository repo = new TempRepository();

            var temperatureData = repo.ParseTemperatureDataFile();

            Assert.IsNotNull(temperatureData);
            Assert.AreEqual(temperatureData.Count, 493);
        }

        [TestMethod]
        public void AddDataToDB()
        {
            TempRepository repo = new TempRepository();

            var temperatureData = repo.ParseTemperatureDataFile();

            bool completed = repo.AddDataToDb(temperatureData);

            var allData = repo.GetData();

            Assert.IsNotNull(temperatureData);
            Assert.IsTrue(completed);
            Assert.AreEqual(allData.Count, 493);
        }

        [TestMethod]
        public void AddDataToDBWithoutDuplicates()
        {
            TempRepository repo = new TempRepository();

            var temperatureData = repo.ParseTemperatureDataFile();

            bool completed0 = repo.AddDataToDb(temperatureData);
            bool completed1 = repo.AddDataToDb(temperatureData);

            var allData = repo.GetData();

            Assert.IsNotNull(temperatureData);
            Assert.IsTrue(completed0);
            Assert.IsTrue(completed1);
            Assert.AreEqual(493, allData.Count);
        }
    }
}

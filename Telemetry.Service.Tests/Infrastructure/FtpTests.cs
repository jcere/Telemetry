using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.Infrastructure;

using Microsoft.Practices.Unity;

namespace Telemetry.Service.Tests.Infrastructure
{
    /// <summary>
    /// Summary description for FtpTests
    /// </summary>
    [TestClass]
    public class FtpTests
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static DAL.DataCollection collector;

        public FtpTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [ClassInitialize]
        public static void MyClassInitialize(TestContext context)
        {
            Logger.StartDebugLogging("TelemetryServiceTests");

            Container.Build();

            collector = Container.Instance.Resolve<DAL.DataCollection>();
        }

        [TestCategory("FtpCollector")]
        [TestMethod]
        public void CollectDataByFtp()
        {
            // setup
            collector.FtpDownload();

            // get local file
            bool exists = 
                System.IO.File.Exists(@"D:\Temp\FtpData\co2_mlo_surface-insitu_1_ccgg_MonthlyData.txt");

            // assert
            Assert.IsTrue(exists);
        }
    }
}

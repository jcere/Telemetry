using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telemetry.Service.Infrastructure;
using log4net.Repository.Hierarchy;
using log4net.Appender;
using System.Linq;

namespace Telemetry.Service.Tests.Infrastructure
{
    [TestClass]
    public class LoggerTests
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [TestMethod]
        public void StartLoggerAndCheckMemoryAppender()
        {

            BootStrapper.Initialize();

            Hierarchy hierarchy = 
                log4net.LogManager.GetRepository() as Hierarchy;

            MemoryAppender mappender = 
                hierarchy.Root.GetAppender("MemoryAppender") as MemoryAppender;

            Assert.IsNotNull(mappender);
        }

        [TestMethod]
        public void CheckErrors()
        {

            BootStrapper.Initialize();

            Hierarchy hierarchy = log4net.LogManager.GetRepository() as Hierarchy;
            MemoryAppender mappender = hierarchy.Root.GetAppender("MemoryAppender") as MemoryAppender;

            for (int i = 0; i < 4; i++)
            {
                log.Debug("Test start logger and memory appender");
            }

            var errors = mappender.GetEvents().ToList();
            Assert.IsNotNull(mappender);
            Assert.AreEqual(errors.Count, 4);
            Assert.AreNotEqual(errors.Count, 5);
        }

        //             log.Debug("Test start logger and memory appender");
    }
}

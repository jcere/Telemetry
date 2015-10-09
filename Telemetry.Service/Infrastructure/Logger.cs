using log4net.Appender;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telemetry.Service.Infrastructure
{
    public class Logger
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string LINE_RETURN = "\r\n";
        private static string addInPath = System.IO.Path.GetDirectoryName(typeof(Logger).Assembly.Location);

        /// <summary>
        /// use this method to start debug logging if using default (programmatic) 
        /// configuration, path is: AssemblyPath\\logs\\{logFileName}.log
        /// </summary>
        public static void StartDebugLogging(string logFileName)
        {
#if DEBUG
            ConfigureLogger(logFileName);
            //OutputLogHeader();
#endif
        }

        /// <summary>
        /// close loggers
        /// </summary>
        public static void CloseDebugLogging()
        {
            log.Logger.Repository.Shutdown();
        }

        /// <summary>
        /// configure logger programmatically given a log file name, defaulting to the path 
        /// (executing assembly)\logs
        /// </summary>
        private static void ConfigureLogger(string logFileName)
        {
            Hierarchy hierarchy = (Hierarchy)log4net.LogManager.GetRepository();

            log4net.Layout.PatternLayout patternLayout = new log4net.Layout.PatternLayout();
            patternLayout.ConversionPattern =
                "%-4timestamp [%thread] %-5level %logger %method - %message%newline";
            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;
            roller.File = System.IO.Path.Combine(addInPath + "\\logs", logFileName + ".log");
            roller.Layout = patternLayout;
            roller.MaxSizeRollBackups = 3;
            roller.MaximumFileSize = "550KB";
            roller.RollingStyle = RollingFileAppender.RollingMode.Size;
            roller.StaticLogFileName = true;
            roller.DatePattern = "yyyy-MM-dd-HH:mm";
            roller.ActivateOptions();

            TraceAppender tracer = new TraceAppender();
            tracer.Layout = patternLayout;
            tracer.ActivateOptions();

            MemoryAppender mappender = new MemoryAppender();
            mappender.Name = "MemoryAppender";

            hierarchy.Root.AddAppender(roller);
            hierarchy.Root.AddAppender(tracer);
            hierarchy.Root.AddAppender(mappender);
            hierarchy.Root.Level = log4net.Core.Level.Debug;
            hierarchy.Configured = true;

        }

        /// <summary>
        /// provide a log header describing some logger configs and/or app version data
        /// </summary>
        public static void OutputLogHeader()
        {
            string shortDate = System.DateTime.Now.ToShortDateString();
            string shortTime = System.DateTime.Now.ToShortTimeString();
            log.Debug(shortDate + "-" + shortTime + " - start new debug log section");

            string enabled = "";
            if (log.IsDebugEnabled) enabled += " Debug ";
            if (log.IsInfoEnabled) enabled += " Info ";
            if (log.IsWarnEnabled) enabled += " Warn ";
            if (log.IsErrorEnabled) enabled += " Error ";
            if (log.IsFatalEnabled) enabled += " Fatal ";

            log.Debug("Enabled:" + enabled + "\r\n");

        }

        /// <summary>
        /// if there are error events logged in the memory appender display in the error dialogue 
        /// </summary>
        /// <param name="clearAfter">if true clear on completion</param>
        public static void DisplayErrorLog(bool clearAfter = false)
        {
            Hierarchy hierarchy = log4net.LogManager.GetRepository() as Hierarchy;
            MemoryAppender mappender = hierarchy.Root.GetAppender("MemoryAppender") as MemoryAppender;

            if (mappender != null)
            {
                var errors = mappender.GetEvents().ToList();
                if (errors != null && errors.Count > 0)
                {
                    // TODO: output errors to web page
                    //ErrorDialogue errWin = new ErrorDialogue(errors);
                    //errWin.ShowDialog();
                }
                if (clearAfter == true) ClearMemoryAppender();
            }
        }

        /// <summary>
        /// if memory appender active, clear errors
        /// </summary>
        public static void ClearMemoryAppender()
        {
            Hierarchy hierarchy = log4net.LogManager.GetRepository() as Hierarchy;
            MemoryAppender mappender = hierarchy.Root.GetAppender("MemoryAppender") as MemoryAppender;
            if (mappender != null)
            {
                mappender.Clear();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Telemetry.Service.DAL.Managers
{
    public class Tools
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// read a text file into an array of strings (lines)
        /// </summary>
        /// <param name="filePath">file to read</param>
        /// <returns>array of strings (lines from file)</returns>
        public static string[] ReadFileIntoArray(string filePath)
        {
            List<string> lineArray = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    do
                    {
                        lineArray.Add(sr.ReadLine());
                    } while (!sr.EndOfStream);
                }
            }
            catch (Exception ex)
            {
                log.Debug(ex);
                return null;
            }
            return lineArray.ToArray();
        }


    }
}
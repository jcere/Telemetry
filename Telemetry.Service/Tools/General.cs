using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Telemetry.Service.Tools
{
    public class General
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Dictionary<string, object> GetPublicProperties(object type)
        {
            return DictionaryFromType(type, BindingFlags.Public);
        }

        private static Dictionary<string, object> DictionaryFromType(object type, BindingFlags @public)
        {

            if (type == null) return new Dictionary<string, object>();

            Type t = type.GetType();
            PropertyInfo[] props = t.GetProperties(@public);
            Dictionary<string, object> dict = new Dictionary<string, object>();
            foreach (PropertyInfo prp in props)
            {
                object value = prp.GetValue(type, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }

    }
}
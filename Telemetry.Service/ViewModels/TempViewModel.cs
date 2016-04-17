using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.DAL.Models;

namespace Telemetry.Service.ViewModels
{
    /// <summary>
    /// temperature data presentation view model
    /// </summary>
    public class TempViewModel
    {

        private static List<string> columns;
        public static List<string> ColumnNames
        {
            get { return GetColumnDescriptors(); }
        }

        public TempViewModel(List<Temperature> collection)
        {
            this.Data = new List<TempSample>();
            foreach (var item in collection)
            {
                this.Data.Add(new TempSample(item.Id, item.Time, item.TempC, item.Volt));
            }
        }


        /// <summary>
        /// temperature plot data
        /// </summary>
        public List<TempSample> Data { get; set; }

        // TODO: get data descriptors from a table of metadata
        public static List<string> GetColumnDescriptors()
        {
            // TEMP: get headers from model properties
            if (columns == null)
            {
                Type atype = typeof(Temperature);
                var dict = Tools.General.GetPublicProperties(atype);
                columns = dict.Keys.ToList();
            }
            return columns;
        }

    }

    public class TempSample
    {
        private string localTime;
         
        public TempSample(int id, double time, double tempC, double voltage)
        {
            Id = id;
            Time = time;
            TempC = tempC;
            Voltage = voltage;
            SetLocalTime();
        }

        public int Id { get; set; }
        public double Time { get; set; }
        public string DateTime { get { return localTime; } }
        public double TempC { get; set; }
        public double Voltage { get; private set; }

        private void SetLocalTime()
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(Time);

            localTime = dateTime.ToLocalTime().ToLongTimeString();
        }
    }
}
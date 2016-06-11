using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.DAL
{
    public class FtpConfiguration : IConfig
    {

        public FtpConfiguration()
        {
            // set defaults
            SetCredentials();
            FileName = "testfile.txt";
            SetPaths();

        }

        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FtpPath { get; set; }
        public string DestPath { get; set; }
        public string FileName { get; set; }

        public void SetCredentials(string userName = "anonymous", string pass = "j.thecat@gmail.com")
        {
            UserName = userName;
            PassWord = pass;
        }

        public void SetPaths()
        {
            FtpPath = 
                @"ftp://aftp.cmdl.noaa.gov/data/trace_gases/co2/in-situ/surface/mlo/co2_mlo_surface-insitu_1_ccgg_MonthlyData.txt";

            var uri = new Uri(FtpPath);

            string fileName = uri.Segments.Last();

            DestPath = @"D:\Temp\FtpData";

            DestPath = System.IO.Path.Combine(DestPath, fileName);
        }
    }
}
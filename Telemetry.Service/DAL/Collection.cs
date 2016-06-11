using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Telemetry.Service.DAL.Interfaces;

namespace Telemetry.Service.DAL
{
    public class DataCollection
    {
        // interface for debug logging
        public static readonly log4net.ILog log = log4net.LogManager
            .GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IConfig config;
        private string userName { get; set; }
        private string passWord { get; set; }

        public DataCollection(IConfig opts)
        {
            this.config = opts;
        }

        public void FtpDownload()
        {
            FtpConfiguration options = config as FtpConfiguration;
            userName = options.UserName;
            passWord = options.PassWord;

            FtpRequest(options.FtpPath, options.DestPath);
        }

        public void FtpRequest(string ftpPath, string destPath)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpPath);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential(userName, passWord);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            try
            {
                WriteResponseToFile(destPath, response, responseStream);
            }
            catch (Exception ex)
            {
                log.Debug(ex);
            }

            reader.Close();
            responseStream.Close();
            response.Close();
        }

        private void WriteResponseToFile(string destPath, FtpWebResponse response, Stream responseStream)
        {
            FileStream writer = new FileStream(destPath, FileMode.Create);

            long length = response.ContentLength;
            int bufferSize = 2048;
            int readCount;
            byte[] buffer = new byte[bufferSize];

            readCount = responseStream.Read(buffer, 0, bufferSize);
            while (readCount > 0)
            {
                writer.Write(buffer, 0, readCount);
                readCount = responseStream.Read(buffer, 0, bufferSize);
            }
            writer.Close();
        }
    }
}
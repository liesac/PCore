using SecurityManagment.Business.Services.Interface;
using SecurityManagment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Services.Implementation
{
    public class LogService : ILogService
    {
        private readonly string NameFile = "LogBackend";

        public void WriteLog(long? idUser, string userName, long? type, long? classification, string message, string stackTrace, string customMessage, string targetSite)
        {
            long idApplication = 1;//CommonSettingsAplication.Default.IdApplication;
            string logDirectory = "Log\\";//CommonSettingsAplication.Default.LogDirectory;

            try
            {
                string domain = AppDomain.CurrentDomain.BaseDirectory.ToString();
                string directory = domain + logDirectory;
                string logFile = NameFile + string.Format("{0:ddMMyyyy}", DateTime.Now) + ".txt";
                WriteFile writeFileIO = new WriteFile(@"" + directory + logFile, System.Text.Encoding.UTF8);
                writeFileIO.write("-----------------------------------");
                writeFileIO.write(string.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now) + (string.IsNullOrEmpty(userName) ? "" : " User :") + userName);
                writeFileIO.write("Custom Message :");
                writeFileIO.write(customMessage);
                writeFileIO.write("Message");
                writeFileIO.write(message);
                writeFileIO.write("StackTrace :");
                writeFileIO.write(stackTrace);
                writeFileIO.close();
            }
            catch (Exception)
            {
            }
        }
    }
}

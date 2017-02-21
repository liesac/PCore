using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Services.Interface
{
    public interface ILogService
    {
        void WriteLog(long? idUser, string userName, long? type, long? classification, string message, string stackTrace, string customMessage, string targetSite);
    }
}

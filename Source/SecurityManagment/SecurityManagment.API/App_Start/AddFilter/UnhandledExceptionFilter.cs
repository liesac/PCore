using SecurityManagment.Business.Services.Implementation;
using SecurityManagment.Business.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SecurityManagment.API.AddFilter
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ILogService logService = new LogService();
            
            string innerMessage = null;
            
            if(context.Exception.InnerException != null)
            {
                innerMessage = context.Exception.InnerException.Message;
            }
            logService.WriteLog(null, null, 1, null, context.Exception.Message, context.Exception.StackTrace, innerMessage, context.Exception.TargetSite.Name);
        }
    }
}
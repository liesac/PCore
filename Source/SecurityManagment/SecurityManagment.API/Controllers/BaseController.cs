using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;

namespace SecurityManagment.API.Controllers
{
    public class BaseController : ApiController
    {
        public IApplicationContext ContextSpring;

        public BaseController()
        {
            if(ContextSpring == null)
            {
                this.ContextSpring = (IApplicationContext)HttpContext.Current.Application["ContextSpring"];
            }
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}

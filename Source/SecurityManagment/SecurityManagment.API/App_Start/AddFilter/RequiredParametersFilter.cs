
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SecurityManagment.API.AddFilter
{
    public class RequiredParametersFilter : ActionFilterAttribute
    {
        // Cache used to store the required parameters for each request based on the
        // request's http method and local path.
        private readonly Dictionary<Tuple<HttpMethod, string>, List<string>> _Cache =  new Dictionary<Tuple<HttpMethod, string>, List<string>>();

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // Get the request's required parameters.
            List<string> requiredParameters = this.GetRequiredParameters(actionContext);

            // If the required parameters are valid then continue with the request.
            // Otherwise, return status code 400.
            ErrorDto dtoError = this.ValidateParameters(actionContext, requiredParameters);
            if (dtoError.Error == true)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, dtoError.Message);
            }
            else
            {
                base.OnActionExecuting(actionContext);
            } 
        }

        private ErrorDto ValidateParameters(HttpActionContext actionContext, List<string> requiredParameters)
        {
            ErrorDto dtoError = new ErrorDto();
            dtoError.Error = false;
            dtoError.Block = false;
            dtoError.Message = "Success";
            // If the list of required parameters is null or containst no parameters 
            // then there is nothing to validate.  
            // Return true.
            if (requiredParameters == null || requiredParameters.Count == 0)
            {
                dtoError.Error = false;
                return dtoError;
            }

            // Attempt to find at least one required parameter that is null.
            List<string> listParameters = new List<string>();
            requiredParameters.ForEach(data => {
                   if(actionContext.ActionArguments.Where(a => a.Key == data && a.Value == null).Count() > 0)
                   {
                       listParameters.Add(data);
                   }
            });

            if(listParameters.Count() > 0)
            {
                dtoError.Error = true;
                dtoError.Block = true;
                dtoError.Message = CommonUtilities.GetJoinStringByCharacter(listParameters," Required","");
            }

            return dtoError;
        }

        private List<string> GetRequiredParameters(HttpActionContext actionContext)
        {
            // Instantiate a list of strings to store the required parameters.
            List<string> result;

            // Instantiate a tuple using the request's http method and the local path.
            // This will be used to add/lookup the required parameters in the cache.
            Tuple<HttpMethod, string> request =
                new Tuple<HttpMethod, string>(
                    actionContext.Request.Method,
                    actionContext.Request.RequestUri.LocalPath);

            // Attempt to find the required parameters in the cache.
            if (!this._Cache.TryGetValue(request, out result))
            {
                // If the required parameters were not found in the cache then get all
                // parameters decorated with the 'RequiredAttribute' from the action context.
                result = actionContext.ActionDescriptor
                    .GetParameters()
                    .Where(p => p.GetCustomAttributes<RequiredAttribute>().FirstOrDefault() != null)
                    .Select(p => p.ParameterName)
                    .ToList();

                // Add the required parameters to the cache.
                this._Cache.Add(request, result);
            }

            // Return the required parameters.
            return result;
        }

    }
}
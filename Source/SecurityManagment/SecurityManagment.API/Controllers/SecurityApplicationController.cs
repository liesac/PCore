using SecurityManagment.Business.Services.Implementation;
using SecurityManagment.Business.Services.Interface;
using SecurityManagment.Common.Dto.Authentication;
using SecurityManagment.Common.Dto.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SecurityManagment.API.Controllers
{
    public class SecurityApplicationController : BaseController
    {
        [HttpGet]
        public ResultUserAuthenticationDto GetAuthentication([Required] string userName, [Required] string password)
        {
            IAuthenticationServices authenticationService = (IAuthenticationServices)this.ContextSpring.GetObject(typeof(AuthenticationServices).Name);
            return authenticationService.GetAuthentication(userName, password);
        }

        [HttpGet]
        public AllowResourcesDto GetAllowResources(string userName, string password, long idCompany, long idApplication, string ticket)
        {
            IAuthenticationServices authenticationService = (IAuthenticationServices)this.ContextSpring.GetObject(typeof(AuthenticationServices).Name);
            return authenticationService.GetAllowResources(userName, password, idCompany, idApplication, ticket);
        }

        [HttpGet]
        public List<ResultRoleDto> GetApplicationUserRole(string ticket, long idCompany, long idApplication, long idUserApplication)
        {
            IAuthenticationServices authenticationService = (IAuthenticationServices)this.ContextSpring.GetObject(typeof(AuthenticationServices).Name);
            return authenticationService.GetApplicationUserRole(ticket, idCompany, idApplication, idUserApplication);
        }

        [HttpGet]
        public ResultRoleDto GetApplicationUserRoleMenu(string ticket, long idCompany, long idApplication, long idUserApplication, long idApplicationRole)
        {
            IAuthenticationServices authenticationService = (IAuthenticationServices)this.ContextSpring.GetObject(typeof(AuthenticationServices).Name);
            return authenticationService.GetApplicationUserRoleMenu(ticket, idCompany, idApplication, idUserApplication, idApplicationRole);
        }

        [HttpGet]
        public List<string> GetSharedSecret(string textPlain)
        {
            IAuthenticationServices authenticationService = (IAuthenticationServices)this.ContextSpring.GetObject(typeof(AuthenticationServices).Name);
            return authenticationService.GetSharedSecret(textPlain);
        }

        [HttpPost]
        public ResultDto SaveChangePassword(ChangePasswordDto dtoChangePassword)
        {
            IAuthenticationServices authenticationService = (IAuthenticationServices)this.ContextSpring.GetObject(typeof(AuthenticationServices).Name);
            return authenticationService.AuthenticationChangePassword(dtoChangePassword);
        }
    }
}

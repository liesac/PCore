using SecurityManagment.Common.Dto.Authentication;
using SecurityManagment.Common.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Services.Interface
{
    public interface IAuthenticationServices
    {
        string Key();

        ResultUserAuthenticationDto GetAuthentication(string userName, string password);

        List<ResultRoleDto> GetApplicationUserRole(string token, long idCompany, long idApplication, long idUserApplication);

        AllowResourcesDto GetAllowResources(string userName, string password, long idCompany, long idApplication, string token);

        ResultRoleDto GetApplicationUserRoleMenu(string ticket, long idCompany, long idApplication, long idUserApplication, long idApplicationRole);

        ResultDto AuthenticationChangePassword(ChangePasswordDto dtoChangePassword);

        string GetServiceToken();

        List<string> GetSharedSecret(string textPlaint);
    }
}

using AutoMapper;
using SecurityManagment.Business.Services.Interface;
using SecurityManagment.Common.Dto.Authentication;
using SecurityManagment.Common.Dto.Response;
using SecurityManagment.Common.Dto.SecurityManagment;
using SecurityManagment.Common.Enum;
using SecurityManagment.Common.Utilities;
using SecurityManagment.Data.Repositories.SecurityManagment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Services.Implementation
{
    public class AuthenticationServices : IAuthenticationServices
    {
        /// <summary>
        /// 
        /// </summary>
        /// <author>Mauricio Suárez Robelto</author>
        /// <company></company>
        /// <date>17/10/2012 04:46 </date>
        public readonly string IdToken = "MYDOMEAPP";

        /// <summary>
        /// 
        /// </summary>
        /// <author>Mauricio Suárez Robelto</author>
        /// <company></company>
        /// <date>06/08/2012 04:27 </date>
        IApplicationRepository ApplicationRepository = null;

        IApplicationRoleRepository ApplicationRoleRepository = null;

        ILastLoginRepository LastLoginRepository = null;

        /// <summary>
        /// 
        /// </summary>
        /// <author>Mauricio Suárez Robelto</author>
        /// <company></company>
        /// <date>08/08/2012 02:43 </date>
        IUserApplicationRepository UserApplicationRepository = null;

        /// <summary>
        /// 
        /// </summary>
        /// <author>Mauricio Suárez Robelto</author>
        /// <company></company>
        /// <date>08/08/2012 02:43 </date>
        IApplicationUserRoleRepository ApplicationUserRoleRepository = null;

        ICompanyApplicationRepository CompanyApplicationRepository = null;

        public string Key()
        {
            return this.IdToken;
        }

        private BasicAuthenticationDto GetBasicAuthentication(string userName, string password,long? idCompany, long? idApplication, string token)
        {
            bool authenticationError = false;
            BasicAuthenticationDto dtoResultUserAuthentication = new BasicAuthenticationDto();
            dtoResultUserAuthentication.AuthenticationCod = Convert.ToInt16(AuthenticationCode.AccessDenied);
            dtoResultUserAuthentication.MessageAuthentication = "AccessDenied";

            if (token != "not apply")
            {
                if(this.GetServiceToken() != token){
                    authenticationError = true;
                    dtoResultUserAuthentication.MessageAuthentication = "AccessDenied";
                }
            }

            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                authenticationError = true;
                dtoResultUserAuthentication.MessageAuthentication = "AccessDenied";
            }

            if (authenticationError == false)
            {
                UserApplicationDto dtoUserApplication = new UserApplicationDto();
                dtoUserApplication.UserName = userName;
                dtoUserApplication.UserPassword = password;
                dtoUserApplication.IdCompany = idCompany;
                dtoUserApplication.State = true;
                dtoUserApplication = UserApplicationRepository.GetUserApplication(dtoUserApplication).FirstOrDefault();

                if (dtoUserApplication == null)
                {
                    authenticationError = true;
                    dtoResultUserAuthentication.MessageAuthentication = "AccessDenied";
                }
                else
                {
                    dtoUserApplication.UserPassword = null;

                    if (dtoUserApplication.EffectiveDate != null && dtoUserApplication.EffectiveDate >= DateTime.Now)
                    {
                        authenticationError = true;
                        dtoResultUserAuthentication.MessageAuthentication = "AccessDenied - Limit Date";
                    }
                    else
                    {
                        dtoResultUserAuthentication.User = dtoUserApplication;
                    }

                    if (idCompany != null && authenticationError == false)
                    {
                        if (dtoResultUserAuthentication.User.IdCompany != idCompany)
                        {
                            authenticationError = true;
                            dtoResultUserAuthentication.MessageAuthentication = "AccessDenied";
                        }
                    }

                    if (idApplication != null && authenticationError == false)
                    {
                        CompanyApplicationDto dtoApplication = new CompanyApplicationDto();
                        dtoApplication.IdApplication = idApplication;
                        dtoApplication.IdCompany = dtoResultUserAuthentication.User.IdCompany;
                        List<CompanyApplicationDto> listApplicationDto = CompanyApplicationRepository.GetCompanyApplication(dtoApplication);

                        if (listApplicationDto.Count != 1)
                        {
                            authenticationError = true;
                            dtoResultUserAuthentication.MessageAuthentication = "AccessDenied";// - ApplicationNotFound";
                        }
                    }
                }
            }

            if (authenticationError == false)
            {
                dtoResultUserAuthentication.AuthenticationCod = Convert.ToInt16(AuthenticationCode.Success);
                dtoResultUserAuthentication.MessageAuthentication = "Success";
            }

            return dtoResultUserAuthentication;
        }

        public ResultUserAuthenticationDto GetAuthentication(string userName, string password)
        {
            userName = Crypto.DecryptStringAes(userName);
            password = Crypto.DecryptStringAes(password);

            BasicAuthenticationDto dtoBasicAuthentication = this.GetBasicAuthentication(userName, password, null, null, "not apply");
            ResultUserAuthenticationDto dtoResultUserAuthentication = new ResultUserAuthenticationDto();
            dtoResultUserAuthentication.AuthenticationCod = dtoBasicAuthentication.AuthenticationCod;
            dtoResultUserAuthentication.MessageAuthentication = dtoBasicAuthentication.MessageAuthentication;

            if (dtoResultUserAuthentication.AuthenticationCod == Convert.ToInt16(AuthenticationCode.Success))
            {
                dtoResultUserAuthentication.UserApplication = Mapper.Map<UserApplicationDto, ResultUserDto>(dtoBasicAuthentication.User);

                CompanyApplicationDto dtoApplication = new CompanyApplicationDto();
                dtoApplication.IdCompany = dtoBasicAuthentication.User.IdCompany;
                dtoApplication.ReferenceTableApplication = true;

                //list aplication
                dtoResultUserAuthentication.ListApplication = CompanyApplicationRepository.GetCompanyApplication(dtoApplication).Select(data => Mapper.Map<ApplicationDto, ResultApplicationDto>(data.Application)).ToList();
                dtoResultUserAuthentication.ListApplication.ForEach(data =>
                {
                    //set ticket by app
                    data.Ticket = GetServiceToken();
                });
            }

            return dtoResultUserAuthentication;
        }

        public List<ResultRoleDto> GetApplicationUserRole(string ticket, long idCompany, long idApplication, long idUserApplication)
        {
            //Get all roles
            List<ResultRoleDto> listResultRoleDto = new List<ResultRoleDto>();
            List<ApplicationUserRoleDto> listApplicationUserRole = new List<ApplicationUserRoleDto>();
            List<ApplicationRoleDto> listApplicationRoleDto = ApplicationRoleRepository.GetApplicationRole(new ApplicationRoleDto() { IdApplication = idApplication });
            listApplicationRoleDto.ForEach(data =>
            {
                listApplicationUserRole.Add(
                    new ApplicationUserRoleDto()
                    {
                        IdCompany = idCompany,
                        IdApplicationRole = data.IdApplicationRole,
                        IdUserApplication = idUserApplication,
                        State = true,
                        ReferenceTableApplicationRole = true,
                        ApplicationRole = new ApplicationRoleDto()
                        {
                            ReferenceTableRole = true,
                            ReferenceTableMenuOption = true,
                            MenuOption = new List<MenuOptionDto>(){
                                new MenuOptionDto(){
                                    ReferenceTablePage = true
                                }
                            }
                        }
                    });
            });

            listApplicationUserRole = ApplicationUserRoleRepository.GetApplicationUserRole(listApplicationUserRole);

            listApplicationUserRole.ForEach(data =>
            {
                ///rol
                ResultRoleDto dtoResultRole = new ResultRoleDto();
                dtoResultRole.IdApplicationRole = data.IdApplicationRole;
                dtoResultRole.RoleName = data.ApplicationRole.Role.RoleName;
                dtoResultRole.RoleDescription = data.ApplicationRole.Role.RoleDescription;
                dtoResultRole.ImageUrl = data.ApplicationRole.Role.ImageUrl;

                ///menu rol
                List<ResultMenuOptionDto> listdtoResultMenuOption = new List<ResultMenuOptionDto>();
                data.ApplicationRole.MenuOption.ForEach(dataMenu =>
                {
                    ResultMenuOptionDto dtoResultMenuOption = new ResultMenuOptionDto();
                    dtoResultMenuOption.IdMenuOption = dataMenu.IdPage;
                    dtoResultMenuOption.IdMenuOptionFather = dataMenu.IdMenuOptionFather;
                    dtoResultMenuOption.Title = dataMenu.Page.Title;
                    dtoResultMenuOption.Url = dataMenu.Page.Url;
                    dtoResultMenuOption.Target = dataMenu.Target;
                    dtoResultMenuOption.PageLock = dataMenu.PageLock;
                    dtoResultMenuOption.IsMenu = dataMenu.IsMenu;
                    listdtoResultMenuOption.Add(dtoResultMenuOption);
                });
                dtoResultRole.ListMenu = listdtoResultMenuOption;

                listResultRoleDto.Add(dtoResultRole);
            });

            return listResultRoleDto;
        }

        public AllowResourcesDto GetAllowResources(string userName, string password, long idCompany, long idApplication, string token)
        {
            userName = Crypto.DecryptStringAes(userName);
            password = Crypto.DecryptStringAes(password);

            BasicAuthenticationDto dtoBasicAuthentication = this.GetBasicAuthentication(userName, password, idCompany, idApplication, token);
            AllowResourcesDto dtoAllowResources = new AllowResourcesDto();
            dtoAllowResources.AuthenticationCod = dtoBasicAuthentication.AuthenticationCod;
            dtoAllowResources.MessageAuthentication = dtoBasicAuthentication.MessageAuthentication;

            if (dtoAllowResources.AuthenticationCod == Convert.ToInt16(AuthenticationCode.Success))
            {
                dtoAllowResources = this.GetAppResources(userName, password, idApplication);
            }

            return dtoAllowResources;
        }

        public ResultDto AuthenticationChangePassword(ChangePasswordDto dtoChangePassword)
        {
            ResultDto dtoresult = new ResultDto();
            dtoresult.ResultCod = Convert.ToInt16(AuthenticationCode.AccessDenied);
            dtoresult.Message = "AccessDenied";

            try
            {
                dtoChangePassword.UserName = Crypto.DecryptStringAes(dtoChangePassword.UserName);
                dtoChangePassword.Password = Crypto.DecryptStringAes(dtoChangePassword.Password);
                dtoChangePassword.NewPassword = Crypto.DecryptStringAes(dtoChangePassword.NewPassword);

                BasicAuthenticationDto dtoBasicAuthentication = GetBasicAuthentication(dtoChangePassword.UserName, dtoChangePassword.Password, dtoChangePassword.IdCompany, dtoChangePassword.IdApplication, dtoChangePassword.Token);

                if (dtoBasicAuthentication.AuthenticationCod == Convert.ToInt16(AuthenticationCode.Success) && !string.IsNullOrEmpty(dtoChangePassword.NewPassword))
                {
                    UserApplicationDto dtoUserApplication = new UserApplicationDto();
                    dtoUserApplication.UserName = dtoChangePassword.UserName;
                    dtoUserApplication.UserPassword = dtoChangePassword.Password;
                    dtoUserApplication.State = true;
                    dtoUserApplication = UserApplicationRepository.GetUserApplication(dtoUserApplication).First();

                    dtoUserApplication.UserPassword = dtoChangePassword.NewPassword.ToUpper();
                    UserApplicationRepository.SaveUserApplication(dtoUserApplication);
                    dtoresult.ResultCod = Convert.ToInt16(AuthenticationCode.Success);
                    dtoresult.Message = "Success";
                }
            }
            catch (Exception)
            {
                dtoresult.ResultCod = Convert.ToInt16(AuthenticationCode.AccessDenied);
                dtoresult.Message = "AccessDenied";
            }

            return dtoresult;
        }

        public ResultRoleDto GetApplicationUserRoleMenu(string ticket, long idCompany, long idApplication, long idUserApplication, long idApplicationRole)
        {
            ResultRoleDto dtoResultRole = GetAuthenticationApplicationUserRole(ticket, idCompany, idApplication, idUserApplication, idApplicationRole).FirstOrDefault();
            if (dtoResultRole != null)
            {
                dtoResultRole.ListMenu = dtoResultRole.ListMenu.Where(filter => filter.IsMenu == true).ToList();
                dtoResultRole.ListMenu.ForEach(data => { data.IsMenu = null; });
                dtoResultRole.ListMenu = RoleMenuSearchFather(dtoResultRole.ListMenu);

                return dtoResultRole;
            }

            return null;
        }

        private List<ResultMenuOptionDto> RoleMenuSearchFather(List<ResultMenuOptionDto> listMenuOption)
        {
            List<ResultMenuOptionDto> listNewMenuOptition = new List<ResultMenuOptionDto>();

            if (listMenuOption != null)
            {
                foreach (ResultMenuOptionDto data in listMenuOption)
                {
                    if (data.IsMenu == null)
                    {
                        listNewMenuOptition.Add(this.RoleMenuSearchSon(data, listMenuOption));
                    }
                }
            }

            return listNewMenuOptition;
        }

        private ResultMenuOptionDto RoleMenuSearchSon(ResultMenuOptionDto newMenuOption, List<ResultMenuOptionDto> listMenuOption)
        {
            if (newMenuOption != null)
            {
                List<ResultMenuOptionDto> listSon = new List<ResultMenuOptionDto>();
                listSon.AddRange(listMenuOption.Where(filter => filter.IdMenuOptionFather == newMenuOption.IdMenuOption));
                newMenuOption.Children = listSon;
                if (newMenuOption.Children.Count > 0)
                {
                    foreach (ResultMenuOptionDto data in newMenuOption.Children)
                    {
                        listMenuOption.Where(datafilter => datafilter.IdMenuOption == data.IdMenuOption).FirstOrDefault().IsMenu = true;
                        this.RoleMenuSearchSon(data, listMenuOption.Where(filter => filter.IsMenu == null).ToList());
                    }
                }

                return newMenuOption;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the application user role.
        /// </summary>
        /// <param name="idUserApplication">The id user application.</param>
        /// <param name="idApplication">The id application.</param>
        /// <returns></returns>
        /// <author>Mauricio Suárez Robelto</author>
        /// <company></company>
        /// <date>08/08/2012 02:44 </date>
        private List<ResultRoleDto> GetAuthenticationApplicationUserRole(string ticket, long idCompany, long idApplication, long idUserApplication, long? idApplicationRole)
        {
            List<ResultRoleDto> list = new List<ResultRoleDto>();

            List<ApplicationUserRoleDto> listApplicationUserRoleDto = new List<ApplicationUserRoleDto>();
            ApplicationUserRoleDto dtoApplicationUserRole = new ApplicationUserRoleDto();
            dtoApplicationUserRole.IdUserApplication = idUserApplication;
            dtoApplicationUserRole.IdApplicationRole = idApplicationRole;
            dtoApplicationUserRole.IdCompany = idCompany;
            dtoApplicationUserRole.State = true;
            dtoApplicationUserRole.ReferenceTableApplicationRole = true;
            dtoApplicationUserRole.ApplicationRole = new ApplicationRoleDto()
            {
                ReferenceTableRole = true,
                ReferenceTableMenuOption = true,
                MenuOption = new List<MenuOptionDto>()
                    {
                        new MenuOptionDto()
                        {
                            ReferenceTablePage = true
                        }
                    }
            };
            listApplicationUserRoleDto.Add(dtoApplicationUserRole);
            listApplicationUserRoleDto = ApplicationUserRoleRepository.GetApplicationUserRole(listApplicationUserRoleDto).Where(filter => filter.ApplicationRole.IdApplication == idApplication).ToList();

            listApplicationUserRoleDto.ForEach(data =>
            {
                ///rol
                ResultRoleDto dtoResultRole = new ResultRoleDto();
                dtoResultRole.IdApplicationRole = data.IdApplicationRole;
                dtoResultRole.RoleName = data.ApplicationRole.Role.RoleName;
                dtoResultRole.RoleDescription = data.ApplicationRole.Role.RoleDescription;
                dtoResultRole.ImageUrl = data.ApplicationRole.Role.ImageUrl;

                ///menu rol
                List<ResultMenuOptionDto> listdtoResultMenuOption = new List<ResultMenuOptionDto>();
                data.ApplicationRole.MenuOption.ForEach(dataMenu =>
                {
                    ResultMenuOptionDto dtoResultMenuOption = new ResultMenuOptionDto();
                    dtoResultMenuOption.IdMenuOption = dataMenu.IdPage;
                    dtoResultMenuOption.IdMenuOptionFather = dataMenu.IdMenuOptionFather;
                    dtoResultMenuOption.Title = dataMenu.Page.Title;
                    dtoResultMenuOption.Url = dataMenu.Page.Url;
                    dtoResultMenuOption.Target = dataMenu.Target;
                    dtoResultMenuOption.PageLock = dataMenu.PageLock;
                    dtoResultMenuOption.IsMenu = dataMenu.IsMenu;
                    listdtoResultMenuOption.Add(dtoResultMenuOption);
                });
                dtoResultRole.ListMenu = listdtoResultMenuOption;

                list.Add(dtoResultRole);
            });

            return list;

        }

        public string GetServiceToken()
        {
            return Crypto.MD5Hash(IdToken + string.Format("{0:yyyyMMdd}", DateTime.Now));
        }

        private void SetLastLogin(long idUserApplication, long idApplication)
        {
            List<LastLoginDto> listLastLogin = LastLoginRepository.GetLastLogin(new LastLoginDto() { IdUserApplication = idUserApplication, IdApplication = idApplication });
            LastLoginDto dtoLastLogin = null;

            if (listLastLogin.Count == 0)
            {
                dtoLastLogin = new LastLoginDto();
                dtoLastLogin.IdApplication = idApplication;
                dtoLastLogin.IdUserApplication = idUserApplication;
            }
            else
            {
                dtoLastLogin = listLastLogin.First();
            }

            if (dtoLastLogin != null)
            {
                dtoLastLogin.LastLoginDate = DateTime.Now;
                LastLoginRepository.SaveLastLogin(dtoLastLogin);
            }
        }

        public List<string> GetSharedSecret(string textPlaint)
        {
            List<string> listEncrypt = new List<string>();

            string[] arraytextPlaint = textPlaint.Split('|');
            foreach (var item in arraytextPlaint)
            {
                listEncrypt.Add(Crypto.EncryptStringAes(item));
            }

            return listEncrypt;
        }

        private AllowResourcesDto GetAppResources(string userName, string password, long idApplication)
        {
            AllowResourcesDto dtoAllowResources = new AllowResourcesDto();
            dtoAllowResources.AuthenticationCod = Convert.ToInt16(AuthenticationCode.Success);
            dtoAllowResources.MessageAuthentication = "Success";
            return dtoAllowResources;
        }
    }
}

using AutoMapper;
using SecurityManagment.Common.Dto.Response;
using SecurityManagment.Common.Dto.SecurityManagment;
using SecurityManagment.Data.EntityModel.SecurityManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Configuration
{
    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>This class register the mapper between the entities and the Dtos.</value>
    /// <author>Mauricio Suarez</author>
    public class MapperCreator
    {
        /// <summary>
        /// Creates the mappers.
        /// </summary>
        /// <value></value>
        /// <author>Mauricio Suarez.</author>
        public static void CreateMappers()
        {
            Mapper.AssertConfigurationIsValid();

            Mapper.CreateMap<CompanyApplication, CompanyApplicationDto>();
            Mapper.CreateMap<CompanyApplicationDto, CompanyApplication>();

            Mapper.CreateMap<Application, ApplicationDto>();
            Mapper.CreateMap<ApplicationDto, Application>();

            Mapper.CreateMap<ApplicationRole, ApplicationRoleDto>();
            Mapper.CreateMap<ApplicationRoleDto, ApplicationRole>();

            Mapper.CreateMap<ApplicationUserRole, ApplicationUserRoleDto>();
            Mapper.CreateMap<ApplicationUserRoleDto, ApplicationUserRole>();

            Mapper.CreateMap<MenuOption, MenuOptionDto>();
            Mapper.CreateMap<MenuOptionDto, MenuOption>();

            Mapper.CreateMap<Page, PageDto>();
            Mapper.CreateMap<PageDto, Page>();

            Mapper.CreateMap<Role, RoleDto>();
            Mapper.CreateMap<RoleDto, Role>();

            Mapper.CreateMap<UserApplication, UserApplicationDto>();
            Mapper.CreateMap<UserApplicationDto, UserApplication>();

            Mapper.CreateMap<LastLogin, LastLoginDto>();
            Mapper.CreateMap<LastLoginDto, LastLogin>();

            Mapper.CreateMap<Notifications, NotificationsDto>();
            Mapper.CreateMap<NotificationsDto, Notifications>();

            Mapper.CreateMap<NotificationsSettings, NotificationsSettingsDto>();
            Mapper.CreateMap<NotificationsSettingsDto, NotificationsSettings>();

            Mapper.CreateMap<AssociateUsersGroup, AssociateUsersGroupDto>();
            Mapper.CreateMap<AssociateUsersGroupDto, AssociateUsersGroup>();

            ////
            Mapper.CreateMap<ApplicationDto, ResultApplicationDto>();
            Mapper.CreateMap<UserApplicationDto, ResultUserDto>();
            Mapper.CreateMap<ApplicationUserRoleDto, ResultApplicationUserRoleDto>();
            Mapper.CreateMap<ApplicationRoleDto, ResultApplicationRoleDto>();
            Mapper.CreateMap<RoleDto, ResultRoleDto>();
            Mapper.CreateMap<NotificationsDto, ResultNotificationsDto>();
        }
    }
}

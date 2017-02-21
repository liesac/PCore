// <copyright file="IApplicationUserRoleRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class IApplicationUserRoleRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the ApplicationUserRole.
    /// </summary>
    /// <value>The ApplicationUserRole.</value>
    /// <author>Mauricio Suárez.</author>
    public interface IApplicationUserRoleRepository
    {
        /// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="listApplicationUserRoleDto">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationUserRoleDto> GetApplicationUserRole(List<ApplicationUserRoleDto> listApplicationUserRoleDto);

        /// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationUserRoleDto">List that contains the DTOs from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationUserRoleDto> GetApplicationUserRole(PaginationDto paginationDto, List<ApplicationUserRoleDto> listApplicationUserRoleDto);

        /// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="dtoApplicationUserRole">that contains the DTO from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationUserRoleDto> GetApplicationUserRole(ApplicationUserRoleDto dtoApplicationUserRole);

        /// <summary>
        /// Gets list object of the table ApplicationUserRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoApplicationUserRole">That contains the DTO from ApplicationUserRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationUserRole.</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationUserRoleDto> GetApplicationUserRole(PaginationDto paginationDto, ApplicationUserRoleDto dtoApplicationUserRole);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetApplicationUserRoleCount(List<ApplicationUserRoleDto> listApplicationUserRoleDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listApplicationUserRoleDto">List of data to store ApplicationUserRole.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        bool SaveApplicationUserRole(List<ApplicationUserRoleDto> listApplicationUserRoleDto);

    }
}
			
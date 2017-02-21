// <copyright file="IApplicationRoleRepository.cs" company="">
// </copyright>
// <author>Mauricio Suarez.</author>
// <summary>This is the INTERFACE from class IApplicationRoleRepository.</summary>
// <date>27-10-2016. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the ApplicationRole.
    /// </summary>
    /// <value>The ApplicationRole.</value>
    /// <author>Mauricio Suarez.</author>
    public interface IApplicationRoleRepository
    {
        /// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole</returns>
        /// <author>Mauricio Suarez.</author>
        List<ApplicationRoleDto> GetApplicationRole(List<ApplicationRoleDto> listApplicationRoleDto);

        /// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationRoleDto">List that contains the DTOs from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
        /// <author>Mauricio Suarez.</author>
        List<ApplicationRoleDto> GetApplicationRole(PaginationDto paginationDto, List<ApplicationRoleDto> listApplicationRoleDto);

        /// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="dtoApplicationRole">that contains the DTO from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
        /// <author>Mauricio Suarez.</author>
        List<ApplicationRoleDto> GetApplicationRole(ApplicationRoleDto dtoApplicationRole);

        /// <summary>
        /// Gets list object of the table ApplicationRole.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoApplicationRole">That contains the DTO from ApplicationRole table that filter the query.</param>
        /// <returns>List object of the table ApplicationRole.</returns>
        /// <author>Mauricio Suarez.</author>
        List<ApplicationRoleDto> GetApplicationRole(PaginationDto paginationDto, ApplicationRoleDto dtoApplicationRole);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suarez.</author>
        int GetApplicationRoleCount(List<ApplicationRoleDto> listApplicationRoleDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listApplicationRoleDto">List of data to store ApplicationRole.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suarez.</author>
        List<ApplicationRoleDto> SaveApplicationRole(List<ApplicationRoleDto> listApplicationRoleDto);
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="dtoApplicationRole">List of data to store ApplicationRole.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suarez.</author>
		List<ApplicationRoleDto> SaveApplicationRole(ApplicationRoleDto dtoApplicationRole);
		
		bool DeleteApplicationRole(List<ApplicationRoleDto> listApplicationRoleDto);

    }
}
			
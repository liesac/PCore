// <copyright file="IApplicationRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class IApplicationRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the Application.
    /// </summary>
    /// <value>The Application.</value>
    /// <author>Mauricio Suárez.</author>
    public interface IApplicationRepository
    {
        List<ApplicationDto> GetApplicationByUser(List<ApplicationUserRoleDto> listApplicationUserRoleDto);

        /// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="listApplicationDto">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationDto> GetApplication(List<ApplicationDto> listApplicationDto);

        /// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listApplicationDto">List that contains the DTOs from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationDto> GetApplication(PaginationDto paginationDto, List<ApplicationDto> listApplicationDto);

        /// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="dtoApplication">that contains the DTO from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationDto> GetApplication(ApplicationDto dtoApplication);

        /// <summary>
        /// Gets list object of the table Application.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoApplication">That contains the DTO from Application table that filter the query.</param>
        /// <returns>List object of the table Application.</returns>
        /// <author>Mauricio Suárez.</author>
        List<ApplicationDto> GetApplication(PaginationDto paginationDto, ApplicationDto dtoApplication);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetApplicationCount(List<ApplicationDto> listApplicationDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listApplicationDto">List of data to store Application.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        bool SaveApplication(List<ApplicationDto> listApplicationDto);

    }
}
			
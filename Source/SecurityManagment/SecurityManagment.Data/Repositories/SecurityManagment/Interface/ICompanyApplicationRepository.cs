// <copyright file="ICompanyApplicationRepository.cs" company="">
// </copyright>
// <author>Mauricio Suarez.</author>
// <summary>This is the INTERFACE from class ICompanyApplicationRepository.</summary>
// <date>27-10-2016. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the CompanyApplication.
    /// </summary>
    /// <value>The CompanyApplication.</value>
    /// <author>Mauricio Suarez.</author>
    public interface ICompanyApplicationRepository
    {
        /// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication</returns>
        /// <author>Mauricio Suarez.</author>
        List<CompanyApplicationDto> GetCompanyApplication(List<CompanyApplicationDto> listCompanyApplicationDto);

        /// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listCompanyApplicationDto">List that contains the DTOs from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
        /// <author>Mauricio Suarez.</author>
        List<CompanyApplicationDto> GetCompanyApplication(PaginationDto paginationDto, List<CompanyApplicationDto> listCompanyApplicationDto);

        /// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="dtoCompanyApplication">that contains the DTO from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
        /// <author>Mauricio Suarez.</author>
        List<CompanyApplicationDto> GetCompanyApplication(CompanyApplicationDto dtoCompanyApplication);

        /// <summary>
        /// Gets list object of the table CompanyApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoCompanyApplication">That contains the DTO from CompanyApplication table that filter the query.</param>
        /// <returns>List object of the table CompanyApplication.</returns>
        /// <author>Mauricio Suarez.</author>
        List<CompanyApplicationDto> GetCompanyApplication(PaginationDto paginationDto, CompanyApplicationDto dtoCompanyApplication);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suarez.</author>
        int GetCompanyApplicationCount(List<CompanyApplicationDto> listCompanyApplicationDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listCompanyApplicationDto">List of data to store CompanyApplication.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suarez.</author>
        List<CompanyApplicationDto> SaveCompanyApplication(List<CompanyApplicationDto> listCompanyApplicationDto);
		
		/// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="dtoCompanyApplication">List of data to store CompanyApplication.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suarez.</author>
		List<CompanyApplicationDto> SaveCompanyApplication(CompanyApplicationDto dtoCompanyApplication);
		
		bool DeleteCompanyApplication(List<CompanyApplicationDto> listCompanyApplicationDto);

    }
}
			
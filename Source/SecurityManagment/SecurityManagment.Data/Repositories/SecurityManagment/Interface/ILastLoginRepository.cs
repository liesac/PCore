// <copyright file="ILastLoginRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class ILastLoginRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the LastLogin.
    /// </summary>
    /// <value>The LastLogin.</value>
    /// <author>Mauricio Suárez.</author>
    public interface ILastLoginRepository
    {
        /// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="listLastLoginDto">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin</returns>
        /// <author>Mauricio Suárez.</author>
        List<LastLoginDto> GetLastLogin(List<LastLoginDto> listLastLoginDto);

        /// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listLastLoginDto">List that contains the DTOs from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
        /// <author>Mauricio Suárez.</author>
        List<LastLoginDto> GetLastLogin(PaginationDto paginationDto, List<LastLoginDto> listLastLoginDto);

        /// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="dtoLastLogin">that contains the DTO from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
        /// <author>Mauricio Suárez.</author>
        List<LastLoginDto> GetLastLogin(LastLoginDto dtoLastLogin);

        /// <summary>
        /// Gets list object of the table LastLogin.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoLastLogin">That contains the DTO from LastLogin table that filter the query.</param>
        /// <returns>List object of the table LastLogin.</returns>
        /// <author>Mauricio Suárez.</author>
        List<LastLoginDto> GetLastLogin(PaginationDto paginationDto, LastLoginDto dtoLastLogin);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetLastLoginCount(List<LastLoginDto> listLastLoginDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listLastLoginDto">List of data to store LastLogin.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        bool SaveLastLogin(List<LastLoginDto> listLastLoginDto);

        bool SaveLastLogin(LastLoginDto dtoLastLogin);

    }
}
			
// <copyright file="IUserApplicationRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class IUserApplicationRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the UserApplication.
    /// </summary>
    /// <value>The UserApplication.</value>
    /// <author>Mauricio Suárez.</author>
    public interface IUserApplicationRepository
    {
        /// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="listUserApplicationDto">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication</returns>
        /// <author>Mauricio Suárez.</author>
        List<UserApplicationDto> GetUserApplication(List<UserApplicationDto> listUserApplicationDto);

        /// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listUserApplicationDto">List that contains the DTOs from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
        /// <author>Mauricio Suárez.</author>
        List<UserApplicationDto> GetUserApplication(PaginationDto paginationDto, List<UserApplicationDto> listUserApplicationDto);

        /// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="dtoUserApplication">that contains the DTO from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
        /// <author>Mauricio Suárez.</author>
        List<UserApplicationDto> GetUserApplication(UserApplicationDto dtoUserApplication);

        /// <summary>
        /// Gets list object of the table UserApplication.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoUserApplication">That contains the DTO from UserApplication table that filter the query.</param>
        /// <returns>List object of the table UserApplication.</returns>
        /// <author>Mauricio Suárez.</author>
        List<UserApplicationDto> GetUserApplication(PaginationDto paginationDto, UserApplicationDto dtoUserApplication);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetUserApplicationCount(List<UserApplicationDto> listUserApplicationDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listUserApplicationDto">List of data to store UserApplication.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        List<UserApplicationDto> SaveUserApplication(List<UserApplicationDto> listUserApplicationDto);

        List<UserApplicationDto> SaveUserApplication(UserApplicationDto dtoUserApplication);

    }
}
			
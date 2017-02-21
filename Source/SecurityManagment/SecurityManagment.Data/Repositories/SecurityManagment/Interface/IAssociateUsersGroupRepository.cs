// <copyright file="IAssociateUsersGroupRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class IAssociateUsersGroupRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the AssociateUsersGroup.
    /// </summary>
    /// <value>The AssociateUsersGroup.</value>
    /// <author>Mauricio Suárez.</author>
    public interface IAssociateUsersGroupRepository
    {
        /// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="listAssociateUsersGroupDto">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup</returns>
        /// <author>Mauricio Suárez.</author>
        List<AssociateUsersGroupDto> GetAssociateUsersGroup(List<AssociateUsersGroupDto> listAssociateUsersGroupDto);

        /// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listAssociateUsersGroupDto">List that contains the DTOs from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
        /// <author>Mauricio Suárez.</author>
        List<AssociateUsersGroupDto> GetAssociateUsersGroup(PaginationDto paginationDto, List<AssociateUsersGroupDto> listAssociateUsersGroupDto);

        /// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="dtoAssociateUsersGroup">that contains the DTO from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
        /// <author>Mauricio Suárez.</author>
        List<AssociateUsersGroupDto> GetAssociateUsersGroup(AssociateUsersGroupDto dtoAssociateUsersGroup);

        /// <summary>
        /// Gets list object of the table AssociateUsersGroup.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoAssociateUsersGroup">That contains the DTO from AssociateUsersGroup table that filter the query.</param>
        /// <returns>List object of the table AssociateUsersGroup.</returns>
        /// <author>Mauricio Suárez.</author>
        List<AssociateUsersGroupDto> GetAssociateUsersGroup(PaginationDto paginationDto, AssociateUsersGroupDto dtoAssociateUsersGroup);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetAssociateUsersGroupCount(List<AssociateUsersGroupDto> listAssociateUsersGroupDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listAssociateUsersGroupDto">List of data to store AssociateUsersGroup.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        bool SaveAssociateUsersGroup(List<AssociateUsersGroupDto> listAssociateUsersGroupDto);

    }
}
			
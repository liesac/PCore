// <copyright file="INotificationsRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class INotificationsRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the Notifications.
    /// </summary>
    /// <value>The Notifications.</value>
    /// <author>Mauricio Suárez.</author>
    public interface INotificationsRepository
    {
        /// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="listNotificationsDto">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsDto> GetNotifications(List<NotificationsDto> listNotificationsDto);

        /// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listNotificationsDto">List that contains the DTOs from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsDto> GetNotifications(PaginationDto paginationDto, List<NotificationsDto> listNotificationsDto);

        /// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="dtoNotifications">that contains the DTO from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsDto> GetNotifications(NotificationsDto dtoNotifications);

        /// <summary>
        /// Gets list object of the table Notifications.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoNotifications">That contains the DTO from Notifications table that filter the query.</param>
        /// <returns>List object of the table Notifications.</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsDto> GetNotifications(PaginationDto paginationDto, NotificationsDto dtoNotifications);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetNotificationsCount(List<NotificationsDto> listNotificationsDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listNotificationsDto">List of data to store Notifications.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        bool SaveNotifications(List<NotificationsDto> listNotificationsDto);

    }
}
			
// <copyright file="INotificationsSettingsRepository.cs" company="">
// </copyright>
// <author>Mauricio Suárez.</author>
// <summary>This is the INTERFACE from class INotificationsSettingsRepository.</summary>
// <date>06-09-2015. </date>
using System.Collections.Generic;
using System.Linq;
using SecurityManagment.Common.Dto;
using SecurityManagment.Common.Dto.SecurityManagment;

namespace SecurityManagment.Data.Repositories.SecurityManagment.Interface
{
	 /// <summary>
    /// Gets or sets the table of the NotificationsSettings.
    /// </summary>
    /// <value>The NotificationsSettings.</value>
    /// <author>Mauricio Suárez.</author>
    public interface INotificationsSettingsRepository
    {
        List<NotificationsSettingsDto> GetUpdateNotifications(List<NotificationsSettingsDto> listFilterNotificationsSettings, bool summaryView);

        /// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="listNotificationsSettingsDto">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsSettingsDto> GetNotificationsSettings(List<NotificationsSettingsDto> listNotificationsSettingsDto);

        /// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="listNotificationsSettingsDto">List that contains the DTOs from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsSettingsDto> GetNotificationsSettings(PaginationDto paginationDto, List<NotificationsSettingsDto> listNotificationsSettingsDto);

        /// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="dtoNotificationsSettings">that contains the DTO from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsSettingsDto> GetNotificationsSettings(NotificationsSettingsDto dtoNotificationsSettings);

        /// <summary>
        /// Gets list object of the table NotificationsSettings.
        /// </summary>
        /// <param name="paginationDto">Attributes to apply the pagination.</param>
        /// <param name="dtoNotificationsSettings">That contains the DTO from NotificationsSettings table that filter the query.</param>
        /// <returns>List object of the table NotificationsSettings.</returns>
        /// <author>Mauricio Suárez.</author>
        List<NotificationsSettingsDto> GetNotificationsSettings(PaginationDto paginationDto, NotificationsSettingsDto dtoNotificationsSettings);

        /// <summary>
        /// number of rows affected
        /// </summary>
        /// <returns>number of rows affected</returns>
        ///<author>Mauricio Suárez.</author>
        int GetNotificationsSettingsCount(List<NotificationsSettingsDto> listNotificationsSettingsDto);

        /// <summary>
        /// Save or update records for the table
        /// </summary>
        /// <param name="listNotificationsSettingsDto">List of data to store NotificationsSettings.</param>
        /// <returns>The result of processing the list.</returns>
        /// <author>Mauricio Suárez.</author>
        bool SaveNotificationsSettings(List<NotificationsSettingsDto> listNotificationsSettingsDto);

    }
}
			
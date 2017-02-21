namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The Notifications.</value>
    /// <author>Mauricio Suárez.</author>
    public class NotificationsDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdNotification.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdNotification { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdNotificationType.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdNotificationType { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Title.</value>
        /// <author>Mauricio Suárez.</author>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Description.</value>
        /// <author>Mauricio Suárez.</author>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Url.</value>
        /// <author>Mauricio Suárez.</author>
        public string Url { get; set; }

        /// <summary>
        /// This is the list DTO from NotificationsSettings.
        /// </summary>
        /// <value>The list NotificationsSettings.</value>
        /// <author>Mauricio Suárez.</author>
        public List<NotificationsSettingsDto> NotificationsSettings { get; set; }

        public bool? ReferenceTableNotificationsSettings { get; set; }

        /// <summary>
        /// This is the DTO from TableRef.
        /// </summary>
        /// <value>The TableRef.</value>
        /// <author>Mauricio Suárez.</author>
        public TableRefDto TableRef { get; set; }

        public bool? ReferenceTableTableRef { get; set; }

    }
}

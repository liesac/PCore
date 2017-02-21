namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The UserGroup.</value>
    /// <author>Mauricio Suárez.</author>
    public class UserGroupDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public int? IdUserGroup { get; set; }

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
        /// This is the list DTO from AssociateUsersGroup.
        /// </summary>
        /// <value>The list AssociateUsersGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public List<AssociateUsersGroupDto> AssociateUsersGroup { get; set; }

        public bool? ReferenceTableAssociateUsersGroup { get; set; }

        /// <summary>
        /// This is the list DTO from NotificationsSettings.
        /// </summary>
        /// <value>The list NotificationsSettings.</value>
        /// <author>Mauricio Suárez.</author>
        public List<NotificationsSettingsDto> NotificationsSettings { get; set; }

        public bool? ReferenceTableNotificationsSettings { get; set; }

    }
}

namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The NotificationsSettings.</value>
    /// <author>Mauricio Suárez.</author>
    public class NotificationsSettingsDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdNotificationsSettings.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdNotificationsSettings { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplication { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdUserApplication { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public int? IdUserGroup { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdNotification.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdNotification { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The StartingDate.</value>
        /// <author>Mauricio Suárez.</author>
        public DateTime? SummaryEndDate { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The EndDate.</value>
        /// <author>Mauricio Suárez.</author>
        public DateTime? DashboardEndDate { get; set; }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        /// <author>Mauricio Suárez Robelto</author>
        //
        /// <date>25/04/2014 09:39 a.m.</date>
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the scheduled task.
        /// </summary>
        /// <value>
        /// The scheduled task.
        /// </value>
        /// <author>Mauricio Suárez Robelto</author>
        //
        /// <date>25/04/2014 10:08 a.m.</date>
        public DateTime? StartingDate { get; set; }

        /// <summary>
        /// This is the DTO from Application.
        /// </summary>
        /// <value>The Application.</value>
        /// <author>Mauricio Suárez.</author>
        public ApplicationDto Application { get; set; }

        public bool? ReferenceTableApplication { get; set; }

        /// <summary>
        /// This is the DTO from Notifications.
        /// </summary>
        /// <value>The Notifications.</value>
        /// <author>Mauricio Suárez.</author>
        public NotificationsDto Notifications { get; set; }

        public bool? ReferenceTableNotifications { get; set; }

        /// <summary>
        /// This is the DTO from UserApplication.
        /// </summary>
        /// <value>The UserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public UserApplicationDto UserApplication { get; set; }

        public bool? ReferenceTableUserApplication { get; set; }

        /// <summary>
        /// This is the DTO from UserGroup.
        /// </summary>
        /// <value>The UserGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public UserGroupDto UserGroup { get; set; }

        public bool? ReferenceTableUserGroup { get; set; }

    }
}

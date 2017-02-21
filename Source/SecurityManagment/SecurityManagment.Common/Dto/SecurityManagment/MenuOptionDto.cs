namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The MenuOption.</value>
    /// <author>Mauricio Suárez.</author>
    public class MenuOptionDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdMenuOption.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdMenuOption { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdPage.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdPage { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdSecurityGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdSecurityGUI { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdMenuOptionFather.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdMenuOptionFather { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplicationRole.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplicationRole { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The PageLock.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? PageLock { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Target.</value>
        /// <author>Mauricio Suárez.</author>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IsMenu.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? IsMenu { get; set; }

        /// <summary>
        /// This is the DTO from ApplicationRole.
        /// </summary>
        /// <value>The ApplicationRole.</value>
        /// <author>Mauricio Suárez.</author>
        public ApplicationRoleDto ApplicationRole { get; set; }

        public bool? ReferenceTableApplicationRole { get; set; }

        /// <summary>
        /// This is the DTO from Page.
        /// </summary>
        /// <value>The Page.</value>
        /// <author>Mauricio Suárez.</author>
        public PageDto Page { get; set; }

        public bool? ReferenceTablePage { get; set; }

        /// <summary>
        /// This is the DTO from Page.
        /// </summary>
        /// <value>The Page.</value>
        /// <author>Mauricio Suárez.</author>
        public PageDto Page1 { get; set; }

        public bool? ReferenceTablePage1 { get; set; }

        /// <summary>
        /// This is the DTO from SecurityGUI.
        /// </summary>
        /// <value>The SecurityGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public SecurityGUIDto SecurityGUI { get; set; }

        public bool? ReferenceTableSecurityGUI { get; set; }

    }
}

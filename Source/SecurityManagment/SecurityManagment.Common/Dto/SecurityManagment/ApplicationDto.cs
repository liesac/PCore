namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The Application.</value>
    /// <author>Mauricio Suárez.</author>
    public class ApplicationDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplication { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The ApplicationName.</value>
        /// <author>Mauricio Suárez.</author>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The ApplicationDescription.</value>
        /// <author>Mauricio Suárez.</author>
        public string ApplicationDescription { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The ValidateActiveDirectory.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? ValidateActiveDirectory { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The ImageUrl.</value>
        /// <author>Mauricio Suárez.</author>
        public string ImageUrl { get; set; }

        /// <summary>
        /// This is the list DTO from ApplicationRole.
        /// </summary>
        /// <value>The list ApplicationRole.</value>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationRoleDto> ApplicationRole { get; set; }

        public bool? ReferenceTableApplicationRole { get; set; }

        /// <summary>
        /// This is the list DTO from LastLogin.
        /// </summary>
        /// <value>The list LastLogin.</value>
        /// <author>Mauricio Suárez.</author>
        public List<LastLoginDto> LastLogin { get; set; }

        public bool? ReferenceTableLastLogin { get; set; }

        /// <summary>
        /// This is the list DTO from Page.
        /// </summary>
        /// <value>The list Page.</value>
        /// <author>Mauricio Suárez.</author>
        public List<PageDto> Page { get; set; }

        public bool? ReferenceTablePage { get; set; }

    }
}

namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The Role.</value>
    /// <author>Mauricio Suárez.</author>
    public class RoleDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdRole.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdRole { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The RoleName.</value>
        /// <author>Mauricio Suárez.</author>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The RoleDescription.</value>
        /// <author>Mauricio Suárez.</author>
        public string RoleDescription { get; set; }

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

    }
}

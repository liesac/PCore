namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;

    public class ApplicationRoleDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplicationRole.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplicationRole { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdRole.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdRole { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplication { get; set; }

        /// <summary>
        /// This is the list DTO from ApplicationUserRole.
        /// </summary>
        /// <value>The list ApplicationUserRole.</value>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationUserRoleDto> ApplicationUserRole { get; set; }

        public bool? ReferenceTableApplicationUserRole { get; set; }

        /// <summary>
        /// This is the list DTO from MenuOption.
        /// </summary>
        /// <value>The list MenuOption.</value>
        /// <author>Mauricio Suárez.</author>
        public List<MenuOptionDto> MenuOption { get; set; }

        public bool? ReferenceTableMenuOption { get; set; }

        /// <summary>
        /// This is the DTO from Application.
        /// </summary>
        /// <value>The Application.</value>
        /// <author>Mauricio Suárez.</author>
        public ApplicationDto Application { get; set; }

        public bool? ReferenceTableApplication { get; set; }

        /// <summary>
        /// This is the DTO from Role.
        /// </summary>
        /// <value>The Role.</value>
        /// <author>Mauricio Suárez.</author>
        public RoleDto Role { get; set; }

        public bool? ReferenceTableRole { get; set; }

    }
}

namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The UserApplication.</value>
    /// <author>Mauricio Suárez.</author>
    public class UserApplicationDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdUserApplication { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdCompany.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdCompany { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Name.</value>
        /// <author>Mauricio Suárez.</author>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Surname.</value>
        /// <author>Mauricio Suárez.</author>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Gender.</value>
        /// <author>Mauricio Suárez.</author>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The DocumentType.</value>
        /// <author>Mauricio Suárez.</author>
        public long? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The DocumentNumber.</value>
        /// <author>Mauricio Suárez.</author>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The EffectiveDate.</value>
        /// <author>Mauricio Suárez.</author>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The UserName.</value>
        /// <author>Mauricio Suárez.</author>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The UserPassword.</value>
        /// <author>Mauricio Suárez.</author>
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The State.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? State { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Email.</value>
        /// <author>Mauricio Suárez.</author>
        public string Email { get; set; }

        /// <summary>
        /// This is the list DTO from ApplicationUserRole.
        /// </summary>
        /// <value>The list ApplicationUserRole.</value>
        /// <author>Mauricio Suárez.</author>
        public List<ApplicationUserRoleDto> ApplicationUserRole { get; set; }

        public bool? ReferenceTableApplicationUserRole { get; set; }

        /// <summary>
        /// This is the list DTO from LastLogin.
        /// </summary>
        /// <value>The list LastLogin.</value>
        /// <author>Mauricio Suárez.</author>
        public List<LastLoginDto> LastLogin { get; set; }

        public bool? ReferenceTableLastLogin { get; set; }

    }
}

namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The LastLogin.</value>
    /// <author>Mauricio Suárez.</author>
    public class LastLoginDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdLastLogin.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdLastLogin { get; set; }

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
        /// <value>The LastLoginDate.</value>
        /// <author>Mauricio Suárez.</author>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// This is the DTO from Application.
        /// </summary>
        /// <value>The Application.</value>
        /// <author>Mauricio Suárez.</author>
        public ApplicationDto Application { get; set; }

        public bool? ReferenceTableApplication { get; set; }

        /// <summary>
        /// This is the DTO from UserApplication.
        /// </summary>
        /// <value>The UserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public UserApplicationDto UserApplication { get; set; }

        public bool? ReferenceTableUserApplication { get; set; }

    }
}

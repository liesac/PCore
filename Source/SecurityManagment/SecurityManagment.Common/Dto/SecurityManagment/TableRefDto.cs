namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The TableRef.</value>
    /// <author>Mauricio Suárez.</author>
    public class TableRefDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdReference.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdReference { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdGroup { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Name.</value>
        /// <author>Mauricio Suárez.</author>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Description.</value>
        /// <author>Mauricio Suárez.</author>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Value.</value>
        /// <author>Mauricio Suárez.</author>
        public string Value { get; set; }

        /// <summary>
        /// This is the DTO from Group.
        /// </summary>
        /// <value>The Group.</value>
        /// <author>Mauricio Suárez.</author>
        public GroupDto Group { get; set; }

        public bool? ReferenceTableGroup { get; set; }

    }
}

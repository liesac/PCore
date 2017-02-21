namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The Group.</value>
    /// <author>Mauricio Suárez.</author>
    public class GroupDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdGroup { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The DescriptionGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public string DescriptionGroup { get; set; }

        /// <summary>
        /// This is the list DTO from TableRef.
        /// </summary>
        /// <value>The list TableRef.</value>
        /// <author>Mauricio Suárez.</author>
        public List<TableRefDto> TableRef { get; set; }

        public bool? ReferenceTableTableRef { get; set; }

    }
}

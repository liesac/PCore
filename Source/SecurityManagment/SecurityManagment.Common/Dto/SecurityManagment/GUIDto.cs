namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The GUI.</value>
    /// <author>Mauricio Suárez.</author>
    public class GUIDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdGUI { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdentifierGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public string IdentifierGUI { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdPage.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdPage { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Description.</value>
        /// <author>Mauricio Suárez.</author>
        public string Description { get; set; }

        /// <summary>
        /// This is the list DTO from SecurityGUI.
        /// </summary>
        /// <value>The list SecurityGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public List<SecurityGUIDto> SecurityGUI { get; set; }

        public bool? ReferenceTableSecurityGUI { get; set; }

        /// <summary>
        /// This is the DTO from Page.
        /// </summary>
        /// <value>The Page.</value>
        /// <author>Mauricio Suárez.</author>
        public PageDto Page { get; set; }

        public bool? ReferenceTablePage { get; set; }

    }
}

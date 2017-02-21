namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The Page.</value>
    /// <author>Mauricio Suárez.</author>
    public class PageDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdPage.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdPage { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Title.</value>
        /// <author>Mauricio Suárez.</author>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Url.</value>
        /// <author>Mauricio Suárez.</author>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplication { get; set; }

        /// <summary>
        /// This is the list DTO from GUI.
        /// </summary>
        /// <value>The list GUI.</value>
        /// <author>Mauricio Suárez.</author>
        public List<GUIDto> GUI { get; set; }

        public bool? ReferenceTableGUI { get; set; }

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

    }
}

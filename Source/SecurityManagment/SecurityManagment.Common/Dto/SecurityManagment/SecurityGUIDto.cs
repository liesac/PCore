namespace SecurityManagment.Common.Dto.SecurityManagment
{
    using System;
    using System.Collections.Generic;
    /// <summary>
    /// Gets or sets the columna of the application.
    /// </summary>
    /// <value>The SecurityGUI.</value>
    /// <author>Mauricio Suárez.</author>
    public class SecurityGUIDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdSecurityGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdSecurityGUI { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdGUI.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdGUI { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The ControlLock.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? ControlLock { get; set; }

        /// <summary>
        /// This is the list DTO from MenuOption.
        /// </summary>
        /// <value>The list MenuOption.</value>
        /// <author>Mauricio Suárez.</author>
        public List<MenuOptionDto> MenuOption { get; set; }

        public bool? ReferenceTableMenuOption { get; set; }

        /// <summary>
        /// This is the DTO from GUI.
        /// </summary>
        /// <value>The GUI.</value>
        /// <author>Mauricio Suárez.</author>
        public GUIDto GUI { get; set; }

        public bool? ReferenceTableGUI { get; set; }

    }
}

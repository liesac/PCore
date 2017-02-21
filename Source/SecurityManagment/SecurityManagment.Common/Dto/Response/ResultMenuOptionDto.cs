using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Response
{
    /// <summary>
	/// Gets or sets the columna of the application.
	/// </summary>
	/// <value>The MenuOption.</value>
	/// <author>Mauricio Suárez.</author>
	public class ResultMenuOptionDto : BaseDto
	{
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdMenuOption.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdMenuOption { get; set; }

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
		
        ///// <summary>
        ///// Gets or sets the column of the application.
        ///// </summary>
        ///// <value>The IdPage.</value>
        ///// <author>Mauricio Suárez.</author>
        //public long? IdPage { get; set; }
		
        ///// <summary>
        ///// Gets or sets the column of the application.
        ///// </summary>
        ///// <value>The IdSecurityGUI.</value>
        ///// <author>Mauricio Suárez.</author>
        //public long? IdSecurityGUI { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The IdMenuOptionFather.</value>
		/// <author>Mauricio Suárez.</author>
		public long? IdMenuOptionFather { get; set; }
		
        ///// <summary>
        ///// Gets or sets the column of the application.
        ///// </summary>
        ///// <value>The IdApplicationRole.</value>
        ///// <author>Mauricio Suárez.</author>
        //public long? IdApplicationRole { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The PageLock.</value>
		/// <author>Mauricio Suárez.</author>
		public bool? PageLock { get; set; }
		
		/// <summary>
		/// Gets or sets the column of the application.
		/// </summary>
		/// <value>The Target.</value>
		/// <author>Mauricio Suárez.</author>
		public string Target { get; set; }

        public bool? IsMenu { get; set; }

        public List<ResultMenuOptionDto> Children  { get; set; }
		
        ///// <summary>
        ///// This is the list DTO from MenuOption.
        ///// </summary>
        ///// <value>The list MenuOption.</value>
        ///// <author>Mauricio Suárez.</author>
        //public List<MenuOptionDto> ListMenuOption { get; set; }
	
        ///// <summary>
        ///// This is the DTO from MenuOption.
        ///// </summary>
        ///// <value>The MenuOption.</value>
        ///// <author>Mauricio Suárez.</author>
        //public MenuOptionDto MenuOption { get; set; }
	
        //public bool? ReferenceTableMenuOption { get; set; }
		
        ///// <summary>
        ///// This is the DTO from ApplicationRole.
        ///// </summary>
        ///// <value>The ApplicationRole.</value>
        ///// <author>Mauricio Suárez.</author>
        //public ApplicationRoleDto ApplicationRole { get; set; }
	
        //public bool? ReferenceTableApplicationRole { get; set; }
		
        ///// <summary>
        ///// This is the DTO from Page.
        ///// </summary>
        ///// <value>The Page.</value>
        ///// <author>Mauricio Suárez.</author>
        //public PageDto Page { get; set; }
	
        //public bool? ReferenceTablePage { get; set; }
		
        ///// <summary>
        ///// This is the DTO from SecurityGUI.
        ///// </summary>
        ///// <value>The SecurityGUI.</value>
        ///// <author>Mauricio Suárez.</author>
        //public SecurityGUIDto SecurityGUI { get; set; }
	
        //public bool? ReferenceTableSecurityGUI { get; set; }
		
	}
}

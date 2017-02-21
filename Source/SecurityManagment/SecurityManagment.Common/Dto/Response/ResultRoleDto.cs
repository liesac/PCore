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
    /// <value>The Role.</value>
    /// <author>Mauricio Suárez.</author>
    public class ResultRoleDto : BaseDto
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
        ///public long? IdRole { get; set; }

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

        public List<ResultMenuOptionDto> ListMenu { get; set; }

    }
}

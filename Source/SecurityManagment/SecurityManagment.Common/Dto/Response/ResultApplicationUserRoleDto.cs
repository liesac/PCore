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
    /// <value>The ApplicationUserRole.</value>
    /// <author>Mauricio Suárez.</author>
    public class ResultApplicationUserRoleDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplicationUserRole.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplicationUserRole { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdApplicationRole.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdApplicationRole { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdUserApplication { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The State.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? State { get; set; }

        /// <summary>
        /// This is the DTO from ApplicationRole.
        /// </summary>
        /// <value>The ApplicationRole.</value>
        /// <author>Mauricio Suárez.</author>
        public ResultApplicationRoleDto ApplicationRole { get; set; }

    }
}

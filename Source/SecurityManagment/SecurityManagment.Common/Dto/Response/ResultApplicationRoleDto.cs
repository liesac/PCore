using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Response
{
    public class ResultApplicationRoleDto : BaseDto
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
        public long? IdRole { get; set; }

        /// <summary>
        /// This is the DTO from Role.
        /// </summary>
        /// <value>The Role.</value>
        /// <author>Mauricio Suárez.</author>
        public ResultRoleDto Role { get; set; }

    }
}

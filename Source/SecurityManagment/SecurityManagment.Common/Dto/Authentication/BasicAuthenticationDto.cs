using SecurityManagment.Common.Dto.SecurityManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Authentication
{
    public class BasicAuthenticationDto
    {
        public int? AuthenticationCod { get; set; }

        /// <summary>
        /// Gets or sets the message authentication.
        /// </summary>
        /// <value>
        /// The message authentication.
        /// </value>
        /// <author>Mauricio Suárez Robelto</author>
        //
        /// <date>08/08/2012 02:45 </date>
        public string MessageAuthentication { get; set; }

        public UserApplicationDto User { get; set; }
    }
}

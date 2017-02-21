using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Response
{
    public class ResultDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the authentication cod.
        /// </summary>
        /// <value>
        /// The authentication cod.
        /// </value>
        /// <author>Mauricio Suárez Robelto</author>
        /// <date>08/08/2012 02:45 </date>
        public int? ResultCod { get; set; }

        /// <summary>
        /// Gets or sets the message authentication.
        /// </summary>
        /// <value>
        /// The message authentication.
        /// </value>
        /// <author>Mauricio Suárez Robelto</author>
        /// <date>08/08/2012 02:45 </date>
        public string Message { get; set; }
    }
}

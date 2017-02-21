using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.SecurityManagment
{
    public class AssociateUsersGroupDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdAssociateUsersGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdAssociateUsersGroup { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public int? IdUserGroup { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdUserApplication { get; set; }

        /// <summary>
        /// This is the DTO from UserApplication.
        /// </summary>
        /// <value>The UserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public UserApplicationDto UserApplication { get; set; }

        public bool? ReferenceTableUserApplication { get; set; }

        /// <summary>
        /// This is the DTO from UserGroup.
        /// </summary>
        /// <value>The UserGroup.</value>
        /// <author>Mauricio Suárez.</author>
        public UserGroupDto UserGroup { get; set; }

        public bool? ReferenceTableUserGroup { get; set; }

    }
}

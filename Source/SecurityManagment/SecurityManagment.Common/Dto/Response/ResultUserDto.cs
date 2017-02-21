using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Response
{
    public class ResultUserDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdUserApplication.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdUserApplication { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The IdCompany.</value>
        /// <author>Mauricio Suárez.</author>
        public long? IdCompany { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Name.</value>
        /// <author>Mauricio Suárez.</author>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Surname.</value>
        /// <author>Mauricio Suárez.</author>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The Gender.</value>
        /// <author>Mauricio Suárez.</author>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The DocumentType.</value>
        /// <author>Mauricio Suárez.</author>
        public long? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The DocumentNumber.</value>
        /// <author>Mauricio Suárez.</author>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The EffectiveDate.</value>
        /// <author>Mauricio Suárez.</author>
        public DateTime? EffectiveDate { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The UserName.</value>
        /// <author>Mauricio Suárez.</author>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The UserPassword.</value>
        /// <author>Mauricio Suárez.</author>
        public string UserPassword { get; set; }

        /// <summary>
        /// Gets or sets the column of the application.
        /// </summary>
        /// <value>The State.</value>
        /// <author>Mauricio Suárez.</author>
        public bool? State { get; set; }

        public string Email { get; set; }

        public List<ResultRoleDto> Role { get; set; }

        //public List<ResultApplicationUserRoleDto> ApplicationUserRole { get; set; }
    }
}

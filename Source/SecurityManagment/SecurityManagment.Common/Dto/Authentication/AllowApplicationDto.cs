using SecurityManagment.Common.Dto.SecurityManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Authentication
{
    public class AllowApplicationDto : BasicAuthenticationDto
    {
        public List<ApplicationDto> ListApplication { get; set; }
    }
}

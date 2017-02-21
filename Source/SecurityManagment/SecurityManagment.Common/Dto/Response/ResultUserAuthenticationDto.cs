using SecurityManagment.Common.Dto.SecurityManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Response
{
    public class ResultUserAuthenticationDto : BaseDto
    {
        public ResultUserDto UserApplication { get; set; }

        public List<ResultApplicationDto> ListApplication { get; set; }

        public int? AuthenticationCod { get; set; }

        public string MessageAuthentication { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Authentication
{
    public class ChangePasswordDto
    {
        public string Token { get; set; }

        public long IdCompany { get; set; }

        public long IdApplication { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }
    }
}

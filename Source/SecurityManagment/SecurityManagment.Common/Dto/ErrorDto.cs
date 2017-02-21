using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto
{
    public class ErrorDto
    {
        public bool? Error { get; set; }

        public bool? Block { get; set; }

        public string Message { get; set; }
    }
}

﻿using SecurityManagment.Common.Dto.SecurityManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Response
{
    public class ResultApplicationDto : ApplicationDto 
    {
        public string Ticket { get; set; }
    }
}

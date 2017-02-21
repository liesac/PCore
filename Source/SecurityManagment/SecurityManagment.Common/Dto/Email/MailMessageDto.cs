using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Common.Dto.Email
{
    public class MailMessageDto
    {
        public MailAddressDto From { get; set; }

        public List<MailAddressDto> To { get; set; }

        public List<MailAddressDto> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public List<string> MessageAttachment { get; set; }
    }
}

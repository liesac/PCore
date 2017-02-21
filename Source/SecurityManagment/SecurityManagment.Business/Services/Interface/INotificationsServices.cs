using SecurityManagment.Common.Dto.Email;
using SecurityManagment.Common.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Services.Interface
{
    public interface INotificationsServices
    {
        string SendEmail(MailMessageDto dtoMailMessage);

        List<ResultNotificationsDto> SummaryNotifications(long idApplication, string username, int? specificGroup, long? idNotificationType, bool summaryView, bool onlyMainNotification);
    }
}

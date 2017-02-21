using AutoMapper;
using SecurityManagment.Business.Services.Interface;
using SecurityManagment.Common.Configuration;
using SecurityManagment.Common.Dto.Email;
using SecurityManagment.Common.Dto.Response;
using SecurityManagment.Common.Dto.SecurityManagment;
using SecurityManagment.Common.Enum;
using SecurityManagment.Data.Repositories.SecurityManagment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SecurityManagment.Business.Services.Implementation
{
    public class NotificationsServices: INotificationsServices
    {
        IUserApplicationRepository UserApplicationRepository = null;

        IAssociateUsersGroupRepository AssociateUsersGroupRepository = null;

        INotificationsSettingsRepository NotificationsSettingsRepository = null;

        INotificationsRepository NotificationsRepository = null;

        public List<ResultNotificationsDto> SummaryNotifications(long idApplication, string username, int? specificGroup, long? idNotificationType, bool summaryView, bool onlyMainNotification)
        {
            long? idUser = null;
            List<ResultNotificationsDto> listNotificationsDto = new List<ResultNotificationsDto>();
            List<AssociateUsersGroupDto> listgroup = new List<AssociateUsersGroupDto>();

            if (!string.IsNullOrEmpty(username))
            {
                List<UserApplicationDto> listUser = UserApplicationRepository.GetUserApplication(new UserApplicationDto() { UserName = username });
                if (listUser.Count() == 0)
                {
                    return new List<ResultNotificationsDto>();
                }
                else
                {
                    idUser = listUser.First().IdUserApplication.Value;
                    listgroup = AssociateUsersGroupRepository.GetAssociateUsersGroup(new AssociateUsersGroupDto() { IdUserApplication = idUser, IdUserGroup = specificGroup });
                }
            }

            List<NotificationsSettingsDto> listConfigNoti = new List<NotificationsSettingsDto>();

            //IdUserGroup = 0 All User Group
            listConfigNoti.Add(new NotificationsSettingsDto() { IdApplication = idApplication, IdUserGroup = 0, Active = true });
            if (idUser != null)
            {
                listConfigNoti.Add(new NotificationsSettingsDto() { IdApplication = idApplication, IdUserApplication = idUser, Active = true });
            }

            listgroup.ForEach(data =>
            {
                listConfigNoti.Add(new NotificationsSettingsDto() { IdApplication = idApplication, IdUserGroup = data.IdUserGroup, Active = true });
            });


            listConfigNoti = NotificationsSettingsRepository.GetUpdateNotifications(listConfigNoti, summaryView);

            if (onlyMainNotification == true)
            {
                idNotificationType = (long)EnumReferenceTable.MainNotifications;
            }

            List<NotificationsDto> listNoti = new List<NotificationsDto>();
            listConfigNoti.Select(data => data.IdNotification).Distinct().ToList().ForEach(data =>
            {
                listNoti.Add(new NotificationsDto() { IdNotification = data , IdNotificationType = idNotificationType });
            });

            if (listNoti.Count > 0)
            {
                listNotificationsDto = NotificationsRepository.GetNotifications(listNoti).Select(Mapper.Map<NotificationsDto, ResultNotificationsDto>).ToList();
            }

            if (onlyMainNotification != true)
            {
                listNotificationsDto.RemoveAll(filter => filter.IdNotificationType == (long)EnumReferenceTable.MainNotifications);
            }

            return listNotificationsDto;
        }

        //Email
        private string CheckSendEmail(MailMessageDto dtoMailMessage)
        {
            string result = null;

            if (dtoMailMessage.From == null || String.IsNullOrEmpty(dtoMailMessage.From.Address))
            {
                result = CommonSettingsAplication.Default.MESSFromAddress;
            }

            if (dtoMailMessage.To == null || dtoMailMessage.To.Count() == 0)
            {
                result = CommonSettingsAplication.Default.MESSToAddress;
            }

            if (dtoMailMessage.MessageAttachment != null)
            {
                dtoMailMessage.MessageAttachment.ForEach(filename =>
                {
                    if (String.IsNullOrEmpty(filename))
                    {
                        result = "Attachment file not found";
                    }
                });
            }

            return result;
        }

        public string SendEmail(MailMessageDto dtoMailMessage)
        {

            string output = "SendEmail Error";

            if (dtoMailMessage != null)
            {
                try
                {
                    string checkEmail = this.CheckSendEmail(dtoMailMessage);
                    if (checkEmail == null)
                    {
                        MailMessage email = new MailMessage();
                        email.BodyEncoding = Encoding.UTF8;

                        email.From = new MailAddress(dtoMailMessage.From.Address);
                        dtoMailMessage.To.ForEach(dataTo => {
                            if (dataTo != null)
                            {
                                email.To.Add(new MailAddress(dataTo.Address));
                            }
                        });

                        if (dtoMailMessage.Bcc != null)
                        {
                            dtoMailMessage.Bcc.ForEach(dataBcc => {
                                MailAddress copy = new MailAddress(dataBcc.Address);
                                email.Bcc.Add(copy);
                            });
                            
                        }
                        
                        email.Subject = dtoMailMessage.Subject;
                        email.Body = dtoMailMessage.Body;
                        email.IsBodyHtml = true;
                        email.Priority = MailPriority.Normal;

                        if (dtoMailMessage.MessageAttachment != null)
                        {
                            dtoMailMessage.MessageAttachment.ForEach(filename =>
                            {
                                //string filename = @"D:/ms/HD/Proyectos/Pedidos/Desarrollo/Fuentes/Order/WebClient/TempFile/DownloadFile/CT10113.pdf";
                                Attachment messageAttachment = new Attachment(filename, MediaTypeNames.Application.Octet);
                                email.Attachments.Add(messageAttachment);
                            });
                        }
                        
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = CommonSettingsAplication.Default.SMTPHost;
                        smtp.Port = 25;
                        smtp.EnableSsl = false;
                        smtp.UseDefaultCredentials = false;
                        //smtp.Credentials = new NetworkCredential("hd.colombia@hdlao.com","");

                        smtp.Send(email);
                        email.Dispose();
                        output = "1- "+CommonSettingsAplication.Default.MESSSMTPSucess;
                    }
                    else
                    {
                        return checkEmail;
                    }
                }
                catch (Exception ex)
                {
                    output = CommonSettingsAplication.Default.MESSSMTPError + ex.Message;
                }
            }

            return output;
        }
    }
}

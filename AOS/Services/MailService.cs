using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace AOS.Services
{
    public class MailService : IMailService
    {
        public void SendEmail(string subject, string body, List<string> to, List<string> cc, List<string> bcc = null, string ReplyTo = null, List<Attachment> attachments = null)
        {
            var message = new MailMessage();
            message.From = new MailAddress(WebConfigurationManager.AppSettings["EmailService.Address"], WebConfigurationManager.AppSettings["EmailService.Name"]);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            foreach (var email in to)
            {
                message.To.Add(new MailAddress(email));
            }

            if (cc != null && cc.Count() > 0)
            {
                foreach (var email in cc)
                {
                    message.CC.Add(new MailAddress(email));
                }
            }

            if (bcc != null && bcc.Count() > 0)
            {
                foreach (var email in bcc)
                {
                    message.Bcc.Add(new MailAddress(email));
                }
            }

            if (ReplyTo != null)
            {
                message.ReplyToList.Add(ReplyTo);
            }

            if (attachments != null && attachments.Count() > 0)
            {
                foreach (var attachment in attachments)
                {
                    message.Attachments.Add(attachment);
                }
            }

            SmtpClient SMTP = new SmtpClient();
            SMTP.Host = WebConfigurationManager.AppSettings["EmailService.SMTP"];
            SMTP.Credentials = new NetworkCredential("_LDAP_Query", "anonymous");
            SMTP.UseDefaultCredentials = false;
            //SMTP.Port = System.Convert.ToInt32(ConfigurationManager.AppSettings["EmailService.Port"]);
            SMTP.Send(message);
            SMTP.Dispose();
        }
    }
}
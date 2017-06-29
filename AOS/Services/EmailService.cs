using Microsoft.AspNet.Identity;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace AOS.Services
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(WebConfigurationManager.AppSettings["EmailService.Address"], WebConfigurationManager.AppSettings["EmailService.Name"]);
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.Body = message.Body;
            msg.IsBodyHtml = true;
            
            using (var SMTP = new SmtpClient()
            {
                Host = WebConfigurationManager.AppSettings["EmailService.SMTP"],
                Credentials = new NetworkCredential("_LDAP_Query", "anonymous"),
                UseDefaultCredentials = false
            })
            {
                await SMTP.SendMailAsync(msg);
            }
        }
    }
}

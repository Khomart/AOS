using System.Collections.Generic;
using System.Net.Mail;

namespace AOS.Services
{
    public interface IMailService
    {
        void SendEmail(string subject, string body, List<string> to, List<string> cc, List<string> bcc = null, string ReplyTo = null, List<Attachment> attachments = null);
    }
}

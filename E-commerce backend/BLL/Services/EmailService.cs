using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BLL.Services
{
    public class EmailService
    {

        public static bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var fromEmail = ConfigurationManager.AppSettings["EmailFrom"];
                var password = ConfigurationManager.AppSettings["EmailPassword"];
                var smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
                var smtpPort = int.Parse(ConfigurationManager.AppSettings["SmtpPort"]);

                var mail = new MailMessage();
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;
                mail.From = new MailAddress(fromEmail);

                using (var smtp = new SmtpClient(smtpHost, smtpPort))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, password);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}

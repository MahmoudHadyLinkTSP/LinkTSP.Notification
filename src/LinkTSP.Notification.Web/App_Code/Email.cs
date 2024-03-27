using System.Net.Mail;
using System.Net;
using System.Text;
using System;
using LinkTSP.Notification.Web.Models;

namespace LinkTSP.Notification.Web.App_Code
{
    public class Email
    {
        public static bool SendEmail(string subject, string body, string reciver)
        {
            try
            {
                var emailSetting = EmailSetting.FromFile();
                var msg = new MailMessage()
                {
                    Subject = subject,
                    Body = body,
                    BodyEncoding = Encoding.UTF8,
                    From = new MailAddress(emailSetting.UserName),
                };

                foreach (var item in emailSetting.Bcc.Split(','))
                    msg.Bcc.Add(new MailAddress(item));

                msg.To.Add(new MailAddress(reciver));

                var smtpClient = new SmtpClient(emailSetting.Host)
                {
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(emailSetting.UserName, emailSetting.Password),
                    Port = 587,
                    EnableSsl = true,
                };
                smtpClient.Send(msg);
                msg.Dispose();
                smtpClient.Dispose();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return false;
            }
        }
    }
}

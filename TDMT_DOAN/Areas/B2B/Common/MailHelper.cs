using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Mail;
namespace TDMT_DOAN.Areas.B2B.Common
{
    public class MailHelper
    {
        public bool sendMail(string toEmail, string subject, string content)
        {
            //<add key ="FromEmailAddress" value="nguyenthanhtoan_94@yahoo.com"/>
            //<add key ="FromEmailDisplayName" value="Chấp nhận đấu giá"/>
            //<add key ="FromEmailPassword" value="15975325801668691858"/>
            //<add key ="SMTPHost" value="smtp.mail.yahoo.com"/>
            //<add key ="SMTPPort" value="587"/>
            //<add key ="EnabledSSL" value="true"/>
            //MailMessage ms = new MailMessage(new MailAddress(fromEmailAddress, fromEmailDisplayName), new MailAddress(toEmail));
            //ms.IsBodyHtml = true;
            //ms.Subject = subject;
            //ms.Body = body;

            //var client = new SmtpClient();
            //client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
            //client.Host = smtpHost;
            //client.EnableSsl = enabledSSL;
            //client.Port = 587;
            //client.Send(ms);
            try
            {
                MailMessage mail = new MailMessage();
                var fromEmailAddress = "nguyenthanhtoan_94@yahoo.com";
                //var fromEmailDisplayName = "Chấp nhận đấu giá";
                var fromEmailPassword = "15975325801668691858";
                var smtpHost = "smtp.mail.yahoo.com";
                var smtpPort = 587;
                bool enabledSSL = true;

                string body = content;
                mail.From = new MailAddress(fromEmailAddress);
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                SmtpClient client = new SmtpClient(smtpHost, Convert.ToInt32(smtpPort));
                client.Credentials = new NetworkCredential(fromEmailAddress, fromEmailPassword);
                client.EnableSsl = Convert.ToBoolean(enabledSSL);
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
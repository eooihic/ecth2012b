using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace TDMT_DOAN.Areas.Admin.Code
{
    public class EmailSender
    {
        public static string smtpAddress = "smtp.gmail.com";
        public static int portNumber = 587;
        public static bool enableSSL = true;

        public static string emailFrom = "mrthien30@gmail.com";
        public static string password = "ddqjxvrfoplwbcxy";
        public static string emailTo = "mrthien30@yahoo.com";
        public static string subject = "Test Email";
        public static string body = "Test Email";
        public static void sendMail(string toEmail, string content)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
    }
}
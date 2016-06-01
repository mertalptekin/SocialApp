using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Common.Services.Mail
{
    public class MailService
    {
        private const string EmailAddress ="polengidainfo@gmail.com";
        private const string Password ="zadamoglu";

        public static bool Send(EmailDetail mail){

        MailMessage ePosta = new MailMessage();
        ePosta.From = new MailAddress(mail.From);

        foreach (var item in mail.To)
        {
            ePosta.To.Add(item);
        }

        ePosta.Subject = mail.Subject;
        ePosta.Body = mail.Body;
        ePosta.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Credentials = new NetworkCredential(EmailAddress,Password);

        try
        {
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Send(ePosta);
            return true;
        }
        catch (Exception)
        {

            return false;
        }

        }
    }
}

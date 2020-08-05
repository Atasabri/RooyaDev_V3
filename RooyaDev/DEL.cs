using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace RooyaDev
{
    public class DEL
    {
        public static void Send_Mail(string Subject, HttpPostedFileBase file, List<string> To)
        {
            string From = ConfigurationManager.AppSettings["Email"].ToString();
            string Pass = ConfigurationManager.AppSettings["Password"].ToString();
            string Host = ConfigurationManager.AppSettings["Host"].ToString();
            int Port =int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(From);
            foreach (var item in To)
            {
                if (item.Contains("@"))
                {
                    mail.To.Add(item);
                }
            }
            mail.Subject = Subject;
            StreamReader read = new StreamReader(file.InputStream);
            mail.Body = read.ReadToEnd();
            mail.IsBodyHtml = true;
            ///-------------------------------------------------------------------------//
            SmtpClient smtpMail = new SmtpClient();
            smtpMail.EnableSsl = false;
            smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpMail.Host = Host;
            smtpMail.Port = Port;

            smtpMail.UseDefaultCredentials = false;
            smtpMail.Credentials = new NetworkCredential(From, Pass);
            ///-------------------------------------------------------------------------//
            smtpMail.Send(mail);
        }
        public static void Send_Welcome(string subject, string to, string path)
        {
            string From = ConfigurationManager.AppSettings["Email"].ToString();
            string Pass = ConfigurationManager.AppSettings["Password"].ToString();
            string Host = ConfigurationManager.AppSettings["Host"].ToString();
            int Port = int.Parse(ConfigurationManager.AppSettings["Port"].ToString());
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(From);
            if (to.Contains("@"))
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            StreamReader read = new StreamReader(path);
            mail.Body = read.ReadToEnd();
            mail.IsBodyHtml = true;
            ///-------------------------------------------------------------------------//
            SmtpClient smtpMail = new SmtpClient();
            smtpMail.EnableSsl = false;
            smtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpMail.Host = Host;
            smtpMail.Port = Port;

            smtpMail.UseDefaultCredentials = false;
            smtpMail.Credentials = new NetworkCredential(From, Pass);
            ///-------------------------------------------------------------------------//
            smtpMail.Send(mail);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace ARC.Classes
{
    public static class Email
    {
        public static void Send(string Subject , string body)
        {
            
            string SmtpServerName = WebConfigurationManager.AppSettings["MailServer"].ToString();
            int port = int.Parse(WebConfigurationManager.AppSettings["Port"].ToString());
            string username = WebConfigurationManager.AppSettings["Username"].ToString();
            string password = WebConfigurationManager.AppSettings["Password"].ToString();
            string From = WebConfigurationManager.AppSettings["MailFrom"].ToString();
            string To = WebConfigurationManager.AppSettings["MailTo"].ToString();
            MailMessage Message = new MailMessage(From, To);
            Message.Subject = Subject;
            Message.Body = body;

            SmtpClient client = new SmtpClient(SmtpServerName, port);

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(username, password);
            client.EnableSsl = true;
            client.Timeout = 20000;
            client.Send(Message);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace SHIClassLibrary.Tools
{
    public class EmailManager
    {
        private SmtpClient _SmtpClient;
        private MailMessage _MailMessage;
        
        public EmailManager(string host, int port, string id, string password)
        {
            _SmtpClient = new SmtpClient(host, port);
            _SmtpClient.Credentials = new NetworkCredential(id, password);

            _MailMessage = new MailMessage();
            _MailMessage.IsBodyHtml = true;
            _MailMessage.Priority = MailPriority.Normal;

        }
        public string from
        {
            get { return _MailMessage.From == null ? String.Empty : _MailMessage.From.Address; }
            set { _MailMessage.From = new MailAddress(value); }
        }

        public MailAddressCollection to
        {
            get { return _MailMessage.To; }
        }
        public string Subject
        {
            get { return _MailMessage.Subject; }
            set { _MailMessage.Subject = value; }
        }
        public string Body
        {
            get { return _MailMessage.Body; }
            set { _MailMessage.Body = value; }
        }
        public void Send()
        {
            _SmtpClient.Send(_MailMessage);

        }

        #region Static Methods
        public static void send(string from, string to, string subject, string contents, string cc, string bcc)
        {
            if (String.IsNullOrEmpty(from))
                throw new ArgumentNullException("Sneder is empty.");
            if (String.IsNullOrEmpty(to))
                throw new ArgumentNullException("To is empty.");

            string smtpHost = ConfigurationManager.AppSettings["SMTPHost"];

            int smtpPort = 0;
            if (ConfigurationManager.AppSettings["SMTPPort"] == null ||
                int.TryParse(ConfigurationManager.AppSettings["SMTPPort"], out smtpPort) == false)
                smtpPort = 25;
            string smtpId = ConfigurationManager.AppSettings["SMTPID"];
            string smtpPwd = ConfigurationManager.AppSettings["SMTPPassword"];

            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(from);
            mailMsg.To.Add(to);

            if (!String.IsNullOrEmpty(cc))
                mailMsg.CC.Add(cc);
            if (!String.IsNullOrEmpty(bcc))
                mailMsg.Bcc.Add(bcc);

            mailMsg.Subject = subject;
            mailMsg.IsBodyHtml = true;
            mailMsg.Body = contents;
            mailMsg.Priority = MailPriority.Normal;

        }
        public static void send(string from, string to, string subject, string contents)
        {
            send(from, to, subject, contents,null,null);
        }
        public static void send(string to, string subject, string contents)
        {
            string sender = ConfigurationManager.AppSettings["SMTPSender"];
            send(sender, to, subject, contents);
        }
        #endregion
    }
}

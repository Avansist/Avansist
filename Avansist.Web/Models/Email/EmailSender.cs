using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Models.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSender : IEmailSender
    {
        private readonly EmailSenderOptions _emailSettings;
        public EmailSender(IOptions<EmailSenderOptions> smtpSettings)
        {
            _emailSettings = smtpSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {

            MimeMessage mimeMessage = new();
            mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            mimeMessage.To.Add(new MailboxAddress(email, email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html")
            {
                Text = message
            };

            SmtpClient client = new();
            // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
            client.CheckCertificateRevocation = false;
            await client.ConnectAsync(_emailSettings.Server, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);

            await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
            await client.SendAsync(mimeMessage);
            await client.DisconnectAsync(true);
        }
    }
}

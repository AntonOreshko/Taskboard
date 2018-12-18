using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces.Mail;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace BusinessLayer.Services.Mail
{
    public class EmailService: IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }

        public List<EmailMessage> ReceiveEmail(int maxCount = 10)
        {
            throw new NotImplementedException();
        }

        public async Task SendAsync(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            using (var emailClient = new SmtpClient())
            {
                await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);

                await emailClient.SendAsync(message);

                await emailClient.DisconnectAsync(true);
            }
        }
    }
}

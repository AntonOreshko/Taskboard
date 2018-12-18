using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Services.Mail;

namespace BusinessLayer.Services.Interfaces.Mail
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage emailMessage);

        List<EmailMessage> ReceiveEmail(int maxCount = 10);
    }
}

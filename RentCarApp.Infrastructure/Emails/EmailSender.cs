using System.Threading.Tasks;
using RentCarApp.Application.Configuration.Emails;

namespace RentCarApp.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(EmailMessage message)
        {
            // Integration with email service.

            return;
        }
    }
}
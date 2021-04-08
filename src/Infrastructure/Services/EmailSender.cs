using ShopOnWeb.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // TODO: 
            return Task.CompletedTask;
        }
    }
}

using System.Net;
using System.Net.Mail;

namespace Handyman.Helper
{
    public interface IEmailHelper
    {
        Task SendEmailAsync(string name, string to, string subject, string body);

    }

}

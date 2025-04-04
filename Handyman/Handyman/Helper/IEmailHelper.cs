namespace Handyman.Helper
{
    public interface IEmailHelper
    {
        Task SendEmailAsync(string name, string email, string subject, string message);
    }
}

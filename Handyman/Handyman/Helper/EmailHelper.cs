using System.Net.Mail;
using System.Net;

namespace Handyman.Helper
{
    public class EmailHelper
    {
        public static async Task SendEmailAsync(string name, string email, string subject, string message)
        {
            // Retrieve environment variables
            var smtpUsername = Environment.GetEnvironmentVariable("EMAIL_USERNAME");
            var smtpPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            var smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER");
            var smtpPort = Environment.GetEnvironmentVariable("SMTP_PORT");

            // Validate environment variables
            if (string.IsNullOrEmpty(smtpUsername) || string.IsNullOrEmpty(smtpPassword) ||
                string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(smtpPort))
            {
                throw new Exception("SMTP configuration is missing. Please ensure all environment variables are set.");
            }

            // Validate email parameter
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            // Parse SMTP Port
            if (!int.TryParse(smtpPort, out var port))
            {
                throw new Exception("Invalid SMTP port value.");
            }

            var mailMessage = new MailMessage
            {
                From = new MailAddress(email),
                Subject = subject,
                Body = $"From: {name} ({email})\n\n{message}",
                IsBodyHtml = false
            };
            mailMessage.To.Add(smtpUsername); // Replace with your email

            using (var smtp = new SmtpClient(smtpServer, port))
            {
                smtp.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mailMessage);
            }
        }
    }
}

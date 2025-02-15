using Handyman.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Handyman.Data;
using Microsoft.EntityFrameworkCore;

namespace Handyman.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> services()
        {
            var serviceTypes = await _context.ServiceTypes
                .Include(st => st.Services)
                .ToListAsync();
            
            return View(serviceTypes);
        }
        
        public async Task<IActionResult> servicedetails(int id)
        {
            var service = await _context.Services
                .Include(s => s.ServiceType)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }



        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string name, string email, string subject, string message)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) ||
                string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "All fields are required.";
                return View();
            }

            try
            {
                await SendEmailAsync(name, email, subject, message);
                ViewBag.Message = "Thank you for contacting us!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error sending email: {ex.Message}";
                return View();
            }
        }

        private async Task SendEmailAsync(string name, string email, string subject, string message)
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

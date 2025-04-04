using Handyman.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Handyman.Helper;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration; // For config settings
using MimeKit;
using MailKit.Net.Smtp;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Microsoft.AspNetCore.Authorization;

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

        [HttpGet]
        public async Task<IActionResult> GetServices(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new List<string>()); // Return empty list if query is empty
            }

            var services = await _context.Services
                .Where(s => s.Name.ToLower().Contains(query.ToLower()))
                .OrderBy(s => s.Name)
                .Select(s => new { s.Id, s.Name }) // Select both ID and Name
                .ToListAsync();

            return Json(services);
        }


        public async Task<IActionResult> Services()
        {
            var serviceTypes = await _context.ServiceTypes
                .Include(st => st.Services)
                .ToListAsync();



            return View(serviceTypes);
        }

        public async Task<IActionResult> ServiceDetails(int id)
        {

            var service = await _context.Services
                .Include(s => s.ServiceType)
                .FirstOrDefaultAsync(s => s.Id == id);


            // Prepare a list of addresses to display
            List<Address> addresses = new List<Address>();
            List<Payment> payments = new List<Payment>();

            if (User.Identity.IsAuthenticated)
            {
                // Get the userId from the authenticated user's claims
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


                addresses = await _context.Addresses
                    .Where(a => a.userId == userId)
                    .ToListAsync(); // Use ToListAsync to execute the query asynchronously

                payments = await _context.Payments.Where(a => a.UserId == userId).ToListAsync();
            }

            // Create and return the view model with service and addresses
            var model = new ServiceDetailsViewModel
            {
                Service = service,
                Addresses = addresses,
                Payments = payments
            };

            return View(model);
        }
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> BookService(int serviceId, int addressId, DateTime date, TimeSpan time,
            string notes)
        {
            // Ensure the user is authenticated
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (date.Date < DateTime.Now.Date)
            {
                // Add error message
                TempData["Error"] = "The selected date cannot be in the past. Please select a valid date.";
                return RedirectToAction("ServiceDetails", new { id = serviceId });
            }


            // Get the user's ID from the claims
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _context.Profiles.FirstOrDefaultAsync(u => u.UserId == userId);
            var userEmail = user?.Email;

            // Retrieve the selected address from the database
            var address = await _context.Addresses.FindAsync(addressId);
            if (address == null)
            {
                // If the address is not found, return an error
                TempData["Error"] = "Selected address not found.";
                return RedirectToAction("ServiceDetails", new { id = serviceId });
            }

            // Retrieve the service details
            var service = await _context.Services.Include(s => s.ServiceType)
                .FirstOrDefaultAsync(s => s.Id == serviceId);
            if (service == null)
            {
                // If the service is not found, return an error
                TempData["Error"] = "Service not found.";
                return RedirectToAction("ServiceDetails", new { id = serviceId });
            }

            // Create a new booking
            var booking = new Appointment()
            {
                PersonName = User.Identity.Name,
                Address = $"{address.Street}, {address.City}, {address.State}, {address.PostalCode}, {address.Country}",
                AppointmentDate = date,
                AppointmentTime = time,
                Status = "Pending", // Default status
                ServiceId = serviceId,
                Service = service,
                Cost = service.Cost,
                UserId = userId,
                notes = notes
            };

            // Save the booking to the database
            _context.Appointments.Add(booking);
            await _context.SaveChangesAsync();

            // Provide feedback to the user
            TempData["Success"] = "Your booking has been confirmed!";
            Console.WriteLine(userEmail);
            var ad = $"{address.Street}, {address.City}, {address.State}, {address.PostalCode}, {address.Country}";

            await SendConfirmationEmail(user.FullName, user.Email, date, time, service.Name, ad, service.Cost);


            // Redirect back to the service details page or a confirmation page
            return RedirectToAction("ServiceDetails", new { id = serviceId });
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await EmailHelper.SendEmailAsync(model.Name!, model.Email!, model.Subject!, model.Message!);
                ViewBag.Message = "Thank you for contacting us!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error sending email: {ex.Message}";
                return View();
            }
        }

        private async Task SendConfirmationEmail(string userName, string userEmail, DateTime date, TimeSpan time,
            string serviceName, string serviceAddress, decimal? serviceCost)
        {
            try
            {
                // No need to read config if you are hardcoding credentials
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string senderEmail = "handyman.ca009@gmail.com"; // Replace with your Gmail
                string senderPassword = "bdfk ehoa ybym lgnj"; // Use an App Password

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Handyman Services", senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                message.Subject = "🕒 Appointment Pending Confirmation - Handyman Services";

                string emailBody = $@"
            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px; background-color: #f9f9f9;'>
                <h2 style='color: #007BFF; text-align: center;'>Appointment Pending Confirmation</h2>
                <p style='font-size: 16px; color: #333;'>Dear <strong>{userName}</strong>,</p>
                <p style='font-size: 16px; color: #333;'>Thank you for scheduling your appointment for <strong>{serviceName}</strong>.</p>
                <p style='font-size: 16px; color: #333;'>Your appointment is currently pending confirmation. You will receive a follow-up email shortly once it is confirmed.</p>
                
                <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd;'>
                    <p style='font-size: 16px;'><strong>📅 Date:</strong> {date:dddd, MMMM dd, yyyy}</p>
                    <p style='font-size: 16px;'><strong>⏰ Time:</strong> {time}</p>
                    <p style='font-size: 16px;'><strong>📍 Address:</strong> {serviceAddress}</p>
                    <p style='font-size: 16px;'><strong>💰 Estimated Cost:</strong> ${serviceCost:F2}</p>
                </div>

                <p style='font-size: 16px; color: #333;'>If you have any questions, feel free to <a href='mailto:handyman.ca009@gmail.com' style='color: #007BFF;'>contact us</a>.</p>
                <p style='font-size: 16px; color: #333;'>Thank you for choosing Handyman Services!</p>
                
                <hr style='border: none; border-top: 1px solid #ddd;' />
                <p style='text-align: center; font-size: 14px; color: #777;'>Handyman Services &bull; 📍 Toronto, Canada</p>
            </div>";

                message.Body = new TextPart("html") { Text = emailBody };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending failed: " + ex.Message);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Terms()
        {
            return View();
        }

    }
}
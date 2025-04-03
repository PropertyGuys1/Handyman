using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Org.BouncyCastle.Bcpg;

namespace Handyman.Controllers
{
    [Authorize(Roles ="Provider")]
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ProviderController(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<ActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var provider = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);

            bool isProfileComplete = provider != null && 
                                     !string.IsNullOrEmpty(provider.FullName) && 
                                     !string.IsNullOrEmpty(provider.PhoneNumber);

            var appointments = isProfileComplete 
                ? await _context.Appointments
                    .Where(a => a.Status == "Pending")
                    .OrderBy(a => a.AppointmentDate)
                    .ThenBy(a => a.AppointmentTime)
                    .ToListAsync() 
                : new List<Appointment>(); // Return empty list if profile is incomplete

            ViewBag.IsProfileComplete = isProfileComplete;
            return View(appointments);
        }


        [HttpPost]
        public async Task<ActionResult> AcceptAppointment(int appointmentId, string ProviderId)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Service) // Ensure Service is loaded
                .FirstOrDefaultAsync(a => a.Id == appointmentId);

            if (appointment == null)
            {
                return RedirectToAction("Index"); // Handle invalid appointment
            }

            var user = await _context.Profiles
                .Where(u => u.UserId == appointment.UserId)
                .FirstOrDefaultAsync();

            var provider = await _context.Profiles
                .Where(p => p.UserId == ProviderId)
                .FirstOrDefaultAsync(); // Get provider's profile

            if (user == null || provider == null)
            {
                return RedirectToAction("Index"); // Handle missing user or provider
            }

            // Update the appointment
            appointment.Status = "Accepted";
            appointment.ProviderId = ProviderId; // Assign provider ID
            await _context.SaveChangesAsync();

            // Send notification email with provider details
            await SendAppointmentAcceptedEmail(
                user.FullName,
                user.Email,
                appointment.Service.Name,
                appointment.AppointmentDate,
                provider.FullName,
                provider.PhoneNumber
            );

            return RedirectToAction("Index");
        }

// Updated email method to include provider's details
        private async Task SendAppointmentAcceptedEmail(string? userName, string userEmail, string serviceName,
            DateTime appointmentDate, string providerName, string providerPhone)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string senderEmail = "handyman.ca009@gmail.com";
                string senderPassword = "bdfk ehoa ybym lgnj";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("HandyMan", senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                message.Subject = "✅ Appointment Confirmed";
                
                string emailBody = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px; background-color: #f9f9f9;'>
                        <h2 style='color: #28a745; text-align: center;'>Appointment Confirmation</h2>
                        <p style='font-size: 16px; color: #333;'>Dear <strong>{userName}</strong>,</p>
                        <p style='font-size: 16px; color: #333;'>Your appointment for <strong>{serviceName}</strong> has been <span style='color: #28a745; font-weight: bold;'>Accepted</span>.</p>

                        <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd; margin: 15px 0;'>
                            <h3 style='color: #007BFF;'>Appointment Details:</h3>
                            <p style='font-size: 16px;'><strong>📅 Date & Time:</strong> {appointmentDate:dddd, MMMM d, yyyy hh:mm tt}</p>
                        </div>

                        <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd; margin: 15px 0;'>
                            <h3 style='color: #007BFF;'>Provider Details:</h3>
                            <p style='font-size: 16px;'><strong>👤 Name:</strong> {providerName}</p>
                            <p style='font-size: 16px;'><strong>📞 Contact:</strong> {providerPhone}</p>
                        </div>

                        <p style='font-size: 16px; color: #333;'>We look forward to seeing you soon!</p>
                        <p style='font-size: 16px; color: #333;'>Thank you for choosing our services.</p>

                        <hr style='border: none; border-top: 1px solid #ddd;' />
                        <p style='text-align: center; font-size: 14px; color: #777;'>Your Company Name &bull; 📍 Your Location</p>
                    </div>";

                message.Body = new TextPart("html") { Text = emailBody };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending failed: " + ex.Message);
            }
        }


        public async Task<ActionResult> Appointment(string providerId)
        {
            var appointments = await _context.Appointments
                .Where(a => a.ProviderId == providerId && a.Status == "Accepted")
                .ToListAsync();

            foreach(var item in appointments)
            {
                var service = await _context.Services.Where(a => a.Id == item.ServiceId).SingleOrDefaultAsync();
                item.Service = service;
            }

            var inProgressAppointments = await _context.Appointments
                .Where(a => a.ProviderId == providerId && a.Status == "InProgress")
                .OrderBy(a => a.AppointmentTime)
                .ToListAsync();

            foreach (var item in inProgressAppointments)
            {
                var service = await _context.Services.Where(a => a.Id == item.ServiceId).SingleOrDefaultAsync();
                item.Service = service;
            }

            var completedAppointments = await _context.Appointments
                .Where(a => a.ProviderId == providerId && a.Status == "Completed")
                .OrderByDescending(a => a.AppointmentTime)
                .ToListAsync();

            foreach (var item in completedAppointments)
            {
                var service = await _context.Services.Where(a => a.Id == item.ServiceId).SingleOrDefaultAsync();
                item.Service = service;
            }

            // Create the ViewModel for the provider
            var viewModel = new ProviderAppointmentsViewModel
            {
                UpcomingAppointments = appointments,
                InProgressAppointments = inProgressAppointments,
                CompletedAppointments = completedAppointments
            };

            return View(viewModel);
        }

        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id == appointmentId);

            if (appointment == null)
            {
                return NotFound("Appointment not found.");
            }

            var appointmentDateTime = appointment.AppointmentDate.Add(appointment.AppointmentTime);
            if (appointmentDateTime < DateTime.Now.AddHours(24))
            {
                return BadRequest("Cannot cancel an appointment within 24 hours of the scheduled time.");
            }

            var user = await _context.Profiles
                .Where(u => u.UserId == appointment.UserId)
                .FirstOrDefaultAsync();

            var provider = await _context.Profiles
                .Where(p => p.UserId == appointment.ProviderId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Update appointment status and remove provider
            appointment.Status = "Pending";
            appointment.ProviderId = null;
            await _context.SaveChangesAsync();

            // Send cancellation email to user and provider (if assigned)
            await SendAppointmentCancellationEmail(user.FullName, user.Email, appointment.Service.Name, appointment.AppointmentDate, provider?.FullName, provider?.Email);

            return RedirectToAction("Index");
        }


        private async Task SendAppointmentCancellationEmail(string? userName, string userEmail, string serviceName,
            DateTime appointmentDate, string? providerName, string? providerEmail)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string senderEmail = "handyman.ca009@gmail.com";
                string senderPassword = "bdfk ehoa ybym lgnj";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("HandyMan", senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                if (!string.IsNullOrEmpty(providerEmail))
                {
                    message.Cc.Add(new MailboxAddress(providerName, providerEmail)); // Notify provider if assigned
                }

                message.Subject = "❌ Appointment Canceled";

                string emailBody = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px; background-color: #f9f9f9;'>
                        <h2 style='color: #dc3545; text-align: center;'>Appointment Cancellation</h2>
                        <p style='font-size: 16px; color: #333;'>Dear <strong>{userName}</strong>,</p>
                        <p style='font-size: 16px; color: #333;'>Your appointment for <strong>{serviceName}</strong> has been <span style='color: #dc3545; font-weight: bold;'>canceled</span>.</p>

                        <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd; margin: 15px 0;'>
                            <h3 style='color: #007BFF;'>Appointment Details:</h3>
                            <p style='font-size: 16px;'><strong>📅 Date & Time:</strong> {appointmentDate:dddd, MMMM d, yyyy hh:mm tt}</p>
                        </div>

                        <p style='font-size: 16px; color: #333;'>We apologize for any inconvenience caused.</p>
                        <p style='font-size: 16px; color: #333;'>You can reschedule anytime by booking a new appointment.</p>

                        <hr style='border: none; border-top: 1px solid #ddd;' />
                        <p style='text-align: center; font-size: 14px; color: #777;'>Your Company Name &bull; 📍 Your Location</p>
                    </div>";

                message.Body = new TextPart("html") { Text = emailBody };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(senderEmail, senderPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending failed: " + ex.Message);
            }
        }


        public async Task<IActionResult> Profile(string id)
        {
            var profile = await _context.Profiles
                .Include(p => p.ProviderProfile)
                .ThenInclude(cp => cp.Addresses) // Correctly include the collection of addresses
                .Include(p => p.ProviderProfile.Payments)
                .Include(p => p.ProviderProfile.Appointments)
                .Include(p => p.ProviderProfile.AppointmentFeedbacks)
                .FirstOrDefaultAsync(p => p.UserId == id); // Use the correct ID type

            var address = _context.Addresses.Where(a => a.userId == id);
            var payments = _context.Payments.Where(a => a.UserId == id);
            var appoinments = _context.Appointments.Where(a => a.ProviderId == id && a.Status == "Completed");
            
            var totalbalance = 0;
            
            if (profile == null)
                return NotFound();

            foreach(var item in appoinments)
            {
                totalbalance += item.Cost;
            }

            var viewModel = new UserProfileViewModel
            {
                Profile = profile,
                ProviderProfile = profile.ProviderProfile,
                Addresses = address, // Assign the collection of addresses
                Appointments = appoinments,
                Feedbacks = profile.ProviderProfile?.AppointmentFeedbacks,
                Payments = payments,
                Preferences = profile.ProviderProfile?.ServicesOffered,
                Balance = totalbalance
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditProfile(string Id)
        {
            var userProfile = _context.Profiles
                .Include(p => p.ProviderProfile)
                .FirstOrDefault(p => p.UserId == Id);

            if (userProfile == null)
            {
                return NotFound();
            }

            var model = new UserProfileEditViewModel
            {
                FullName = userProfile.FullName,
                Email = userProfile.Email,
                PhoneNumber = userProfile.PhoneNumber,
                Preferences = userProfile.ProviderProfile?.ServicesOffered
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileEditViewModel model, IFormFile? profileImage)
        {
            if (ModelState.IsValid)
            {
                var profile = await _context.Profiles
                    .Include(p => p.ProviderProfile)
                    .FirstOrDefaultAsync(p => p.UserId == model.Id);

                if (profile != null)
                {
                    profile.FullName = model.FullName;
                    profile.Email = model.Email;
                    profile.PhoneNumber = model.PhoneNumber;
                    profile.UpdatedAt = DateTime.Now;

                    var selectedPreferences = Request.Form["Preferences"];

                    Console.WriteLine("Selected Preferences: " + string.Join(", ", selectedPreferences));

                    // Check if CustomerProfile is null and initialize if necessary
                    if (profile.ProviderProfile == null)
                    {
                        profile.ProviderProfile = new ProviderProfile();
                    }

                    if (selectedPreferences.Count > 0)
                    {
                        profile.ProviderProfile.ServicesOffered = string.Join(", ", selectedPreferences);
                    }
                    else
                    {
                        profile.ProviderProfile.ServicesOffered = string.Empty;
                    }

                    if (profileImage != null && profileImage.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await profileImage.CopyToAsync(memoryStream);
                            profile.ProfileImage = memoryStream.ToArray();
                        }
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Profile", new { id = model.Id });
                }
                else
                {
                    Console.WriteLine("Profile not found.");
                }
            }
            else
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Error: " + error.ErrorMessage);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> StartAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);

            if (appointment != null)
            {
                // Change status to "InProgress"
                appointment.Status = "InProgress"; // Optionally set the start time
                await _context.SaveChangesAsync();
            }

            // Redirect back to the appointment list
            return RedirectToAction("Appointment", "Provider",new{ providerId = appointment.ProviderId});
        }
        

        [HttpPost]
        public async Task<IActionResult> CompleteAppointment(int appointmentId, IFormFile appointmentImage, string appointmentDetails)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);

            if (appointment == null)
            {
                return NotFound();
            }

            // Save Image as byte array
            if (appointmentImage != null && appointmentImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await appointmentImage.CopyToAsync(memoryStream);
                    appointment.AppointmentImage = memoryStream.ToArray();  // Convert image to byte array
                }
            }

            // Update appointment details
            appointment.Status = "Completed";
            appointment.ProviderNote = appointmentDetails;

            await _context.SaveChangesAsync();

            return RedirectToAction("Appointment","Provider",new { providerId = appointment.ProviderId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProfile(string id)
        {
            // Find the user profile
            var userProfile = _context.Profiles
                .FirstOrDefault(p => p.UserId == id);

            if (userProfile == null)
            {
                return NotFound();
            }

            // Find the user in Identity
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            // Delete the profile from the database
            _context.Profiles.Remove(userProfile);
            await _context.SaveChangesAsync();

            // Delete the user from Identity
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest("Failed to delete user.");
            }

            // Log the user out
            await _signInManager.SignOutAsync();

            // Redirect to login page
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddEditPayment(string Id, int? paymentId)
        {

            Console.WriteLine($"GET AddEditAddress - userId: {Id}");

            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("UserId is required.");
            }

            var model = new Payment { UserId = Id };

            if (paymentId.HasValue && paymentId.Value > 0)
            {
                var payment = await _context.Payments.FirstOrDefaultAsync(a => a.Id == paymentId.Value);
                if (payment != null)
                {
                    model.Id = payment.Id; // Assign ID for editing
                    model.CardNumber = payment.CardNumber;
                    model.ExpiryDate = payment.ExpiryDate;
                    model.CardHolderName = payment.CardHolderName;
                    model.CVV = payment.CVV;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditPayment(Payment model)
        {
            Console.WriteLine($"Received Id: {model.Id}");
            Console.WriteLine($"Received UserId: {model.UserId}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($" - {err.ErrorMessage}");
                    }
                }

                return View(model);
            }

            string lastFourDigits = model.CardNumber.Substring(model.CardNumber.Length - 4);
            string cardType = model.CardNumber; // Implement this method if not already done

            if (model.Id == 0) // Create new payment if Id is not set
            {
                _context.Payments.Add(model);
            }
            else
            {
                var existingPayment = await _context.Payments.FindAsync(model.Id);
                if (existingPayment != null)
                {
                    existingPayment.CardNumber = model.CardNumber;
                    existingPayment.CardHolderName = model.CardHolderName;
                    existingPayment.CVV = model.CVV;
                    existingPayment.ExpiryDate = model.ExpiryDate;
                    _context.Payments.Update(existingPayment);
                }
            }

            await _context.SaveChangesAsync();

            // Send email notification
            var user = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == model.UserId);
            
            return RedirectToAction("Profile", new { id = model.UserId });
        }

        [HttpPost]
        public IActionResult DeletePaymentCard(int id)
        {
            var card = _context.Payments.Find(id);
            if (card != null)
            {
                _context.Payments.Remove(card);
                _context.SaveChanges();
            }

            return RedirectToAction("Profile", new { id = card?.UserId });
        }


        [HttpGet]
        public async Task<IActionResult> AddEditAddress(string Id, int? addressId)
        {

            Console.WriteLine($"GET AddEditAddress - userId: {Id}");

            if (string.IsNullOrEmpty(Id))
            {
                return BadRequest("UserId is required.");
            }

            var model = new Address { userId = Id };

            if (addressId.HasValue && addressId.Value > 0)
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId.Value);
                if (address != null)
                {
                    model.Id = address.Id; // Assign ID for editing
                    model.Street = address.Street;
                    model.City = address.City;
                    model.State = address.State;
                    model.PostalCode = address.PostalCode;
                    model.Country = address.Country;
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditAddress(Address model)
        {
            Console.WriteLine($"Received Id: {model.Id}");
            Console.WriteLine($"Received UserId: {model.userId}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"Key: {error.Key}");
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($" - {err.ErrorMessage}");
                    }
                }

                return View(model);
            }

            string oldAddress = string.Empty;
            string newAddress = $"{model.Street}, {model.City}, {model.State} {model.PostalCode}, {model.Country}";

            if (model.Id == 0) // Create new address if Id is not set
            {
                _context.Addresses.Add(model);
            }
            else
            {
                var existingAddress = await _context.Addresses.FindAsync(model.Id);
                if (existingAddress != null)
                {
                    oldAddress = $"{existingAddress.Street}, {existingAddress.City}, {existingAddress.State} {existingAddress.PostalCode}, {existingAddress.Country}";

                    existingAddress.Street = model.Street;
                    existingAddress.City = model.City;
                    existingAddress.State = model.State;
                    existingAddress.PostalCode = model.PostalCode;
                    existingAddress.Country = model.Country;
                    _context.Addresses.Update(existingAddress);
                }
            }

            await _context.SaveChangesAsync();

            // Send email notification
            var user = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == model.userId);
            

            return RedirectToAction("Profile", new { id = model.userId });
        }


        // Action to handle deleting an address
        [HttpPost]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var address = await _context.Addresses.FindAsync(id);


            var userProfileId = address.userId; // Store the UserProfileId before deleting
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return RedirectToAction("Profile", new { id = userProfileId }); // Redirect using the stored UserProfileId


        }


    }
}

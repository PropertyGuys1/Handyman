using System.Diagnostics;
using System.Security.Claims;
using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using MimeKit;
using MailKit.Net.Smtp;

namespace Handyman.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(IWebHostEnvironment hostingEnvironment,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Profile(string id)
        {
            var profile = await _context.Profiles
                .Include(p => p.CustomerProfile)
                .ThenInclude(cp => cp.Addresses) // Correctly include the collection of addresses
                .Include(p => p.CustomerProfile.Payments)
                .Include(p => p.CustomerProfile.Appointments)
                .Include(p => p.CustomerProfile.AppointmentFeedbacks)
                .FirstOrDefaultAsync(p => p.UserId == id); // Use the correct ID type

            var address = _context.Addresses.Where(a => a.userId == id);
            var payments = _context.Payments.Where(a => a.UserId == id);

            if (profile == null)
                return NotFound();



            var viewModel = new UserProfileViewModel
            {
                Profile = profile,
                CustomerProfile = profile.CustomerProfile,
                Addresses = address, // Assign the collection of addresses
                Appointments = profile.CustomerProfile?.Appointments,
                Feedbacks = profile.CustomerProfile?.AppointmentFeedbacks,
                Payments = payments,
                Preferences = profile.CustomerProfile?.Preferences,
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult EditProfile(string Id)
        {
            var userProfile = _context.Profiles
                .Include(p => p.CustomerProfile)
                .FirstOrDefault(p => p.UserId == Id);

            if (userProfile == null)
            {
                return NotFound();
            }

            // Populate the model for editing (create a ViewModel if necessary)
            var model = new UserProfileEditViewModel
            {
                FullName = userProfile.FullName,
                Email = userProfile.Email,
                PhoneNumber = userProfile.PhoneNumber,
                Preferences = userProfile.CustomerProfile?.Preferences
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileEditViewModel model, IFormFile? profileImage)
        {
            if (ModelState.IsValid)
            {
                var profile = await _context.Profiles
                    .Include(p => p.CustomerProfile)
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
                    if (profile.CustomerProfile == null)
                    {
                        profile.CustomerProfile = new CustomerProfile();
                    }

                    if (selectedPreferences.Count > 0)
                    {
                        profile.CustomerProfile.Preferences = string.Join(", ", selectedPreferences);
                    }
                    else
                    {
                        profile.CustomerProfile.Preferences = string.Empty;
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


        public async Task<IActionResult> GetProfileImage(int id)
        {
            var profile = await _context.Profiles
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profile != null && profile.ProfileImage != null)
            {
                return File(profile.ProfileImage, "image/png"); // Adjust the MIME type as needed
            }

            // Return a default image if no profile image is found
            var defaultImagePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", "defaultpic.jpg");
            var defaultImageBytes = await System.IO.File.ReadAllBytesAsync(defaultImagePath);
            return File(defaultImageBytes, "image/jpeg");
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

            if (model.Id == 0) // Create new address if Id is not set
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

            if (model.Id == 0) // Create new address if Id is not set
            {
                _context.Addresses.Add(model);
            }
            else
            {
                var existingAddress = await _context.Addresses.FindAsync(model.Id);
                if (existingAddress != null)
                {
                    existingAddress.Street = model.Street;
                    existingAddress.City = model.City;
                    existingAddress.State = model.State;
                    existingAddress.PostalCode = model.PostalCode;
                    existingAddress.Country = model.Country;
                    _context.Addresses.Update(existingAddress);
                }
            }

            await _context.SaveChangesAsync();
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


        public async Task<IActionResult> Appointments()
        {
            // Get current user (assuming you have a logged-in user)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Fetch appointments for the current user (pending or upcoming appointments)
            var appointments = await _context.Appointments
                .Include(a => a.Service) // Include the service
                .Where(a => a.UserId == userId && a.AppointmentDate >= DateTime.Now)
                .OrderBy(a => a.AppointmentDate)
                .ToListAsync();

            return View(appointments);
        }

        public async Task<IActionResult> CancelAppointment(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment != null && appointment.Status == "Pending")
            {
                appointment.Status = "Cancelled";
                await _context.SaveChangesAsync();

                // Send cancellation email
                var user = await _context.Profiles.FirstOrDefaultAsync(u => u.UserId == appointment.UserId);
                if (user != null)
                {
                    await SendAppointmentCancellationEmail(
                        user.FullName,
                        user.Email,
                        appointment.AppointmentDate,
                        appointment.AppointmentTime,
                        appointment.Service.Name,
                        appointment.Address
                    );
                }

                return RedirectToAction(nameof(Appointments));
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> EditAppointment(int id)
        {
            Console.WriteLine($"GET EditAppointment - ID: {id}");
            
            var appointment = await _context.Appointments
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found");
                return NotFound();
            }

            Console.WriteLine($"Found appointment - Date: {appointment.AppointmentDate}, Time: {appointment.AppointmentTime}");

            if (appointment.Status != "Pending")
            {
                TempData["Error"] = "Only pending appointments can be edited.";
                return RedirectToAction(nameof(Appointments));
            }

            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAppointment(int id, Appointment model)
        {
            Console.WriteLine($"POST EditAppointment - ID: {id}");
            
            var appointment = await _context.Appointments
                .Include(a => a.Service)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (appointment == null)
            {
                Console.WriteLine("Appointment not found");
                return NotFound();
            }

            if (appointment.Status != "Pending")
            {
                TempData["Error"] = "Only pending appointments can be edited.";
                return RedirectToAction(nameof(Appointments));
            }

            // Only validate the fields we want to edit
            if (model.AppointmentDate != default && model.AppointmentTime != default)
            {
                try
                {
                    // Store original values for comparison
                    var originalDate = appointment.AppointmentDate;
                    var originalTime = appointment.AppointmentTime;

                    Console.WriteLine($"Updating appointment - Old Date: {originalDate}, New Date: {model.AppointmentDate}");
                    Console.WriteLine($"Updating appointment - Old Time: {originalTime}, New Time: {model.AppointmentTime}");

                    // Update only the editable fields
                appointment.AppointmentDate = model.AppointmentDate;
                appointment.AppointmentTime = model.AppointmentTime;
                appointment.notes = model.notes;

                    // Keep all other fields unchanged
                await _context.SaveChangesAsync();
                    Console.WriteLine("Appointment updated successfully");

                    // Get user details for email
                    var user = await _context.Profiles.FirstOrDefaultAsync(u => u.UserId == appointment.UserId);
                    if (user != null)
                    {
                        await SendAppointmentUpdateEmail(
                            user.FullName,
                            user.Email,
                            appointment.AppointmentDate,
                            appointment.AppointmentTime,
                            appointment.Service.Name,
                            appointment.Address,
                            appointment.Cost,
                            originalDate,
                            originalTime
                        );
                        Console.WriteLine("Update confirmation email sent");
                    }

                    TempData["SuccessMessage"] = "Appointment successfully updated.";
                    return RedirectToAction(nameof(Appointments));
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating appointment: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while updating the appointment.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please provide both date and time for the appointment.");
            }

            // If we got this far, something failed
            Console.WriteLine("Update failed, returning to form");
            // Repopulate the model with the existing appointment data
            model.Service = appointment.Service;
            model.ServiceId = appointment.ServiceId;
            model.UserId = appointment.UserId;
            model.PersonName = appointment.PersonName;
            model.Address = appointment.Address;
            model.Status = appointment.Status;
            model.Cost = appointment.Cost;
            return View(model);
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }

        private async Task SendAppointmentUpdateEmail(string userName, string userEmail, DateTime newDate, TimeSpan newTime, 
            string serviceName, string serviceAddress, int? serviceCost, DateTime originalDate, TimeSpan originalTime)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string senderEmail = "handyman.ca009@gmail.com";
                string senderPassword = "bdfk ehoa ybym lgnj";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Handyman Services", senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                message.Subject = "🔄 Appointment Update Confirmation - Handyman Services";

                string emailBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px; background-color: #f9f9f9;'>
                    <h2 style='color: #007BFF; text-align: center;'>Appointment Update Confirmation</h2>
                    <p style='font-size: 16px; color: #333;'>Dear <strong>{userName}</strong>,</p>
                    <p style='font-size: 16px; color: #333;'>Your appointment for <strong>{serviceName}</strong> has been successfully updated.</p>
                    
                    <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd; margin: 15px 0;'>
                        <h3 style='color: #dc3545;'>Previous Schedule:</h3>
                        <p style='font-size: 16px;'><strong>📅 Date:</strong> {originalDate:dddd, MMMM dd, yyyy}</p>
                        <p style='font-size: 16px;'><strong>⏰ Time:</strong> {originalTime}</p>
                    </div>

                    <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd;'>
                        <h3 style='color: #28a745;'>New Schedule:</h3>
                        <p style='font-size: 16px;'><strong>📅 Date:</strong> {newDate:dddd, MMMM dd, yyyy}</p>
                        <p style='font-size: 16px;'><strong>⏰ Time:</strong> {newTime}</p>
                        <p style='font-size: 16px;'><strong>📍 Address:</strong> {serviceAddress}</p>
                        <p style='font-size: 16px;'><strong>💰 Cost:</strong> ${serviceCost:F2}</p>
                    </div>

                    <p style='font-size: 16px; color: #333;'>If you have any questions, please <a href='mailto:handyman.ca009@gmail.com' style='color: #007BFF;'>contact us</a>.</p>
                    <p style='font-size: 16px; color: #333;'>Thank you for choosing Handyman Services!</p>
                    
                    <hr style='border: none; border-top: 1px solid #ddd;' />
                    <p style='text-align: center; font-size: 14px; color: #777;'>Handyman Services &bull; 📍 Toronto, Canada</p>
                </div>";

                message.Body = new TextPart("html") { Text = emailBody };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
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

        private async Task SendAppointmentCancellationEmail(string userName, string userEmail, DateTime date, TimeSpan time, 
            string serviceName, string serviceAddress)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string senderEmail = "handyman.ca009@gmail.com";
                string senderPassword = "bdfk ehoa ybym lgnj";

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Handyman Services", senderEmail));
                message.To.Add(new MailboxAddress(userName, userEmail));
                message.Subject = "❌ Appointment Cancellation Confirmation - Handyman Services";

                string emailBody = $@"
                <div style='font-family: Arial, sans-serif; max-width: 600px; margin: auto; border: 1px solid #ddd; border-radius: 8px; padding: 20px; background-color: #f9f9f9;'>
                    <h2 style='color: #dc3545; text-align: center;'>Appointment Cancellation Confirmation</h2>
                    <p style='font-size: 16px; color: #333;'>Dear <strong>{userName}</strong>,</p>
                    <p style='font-size: 16px; color: #333;'>Your appointment for <strong>{serviceName}</strong> has been cancelled as requested.</p>
                    
                    <div style='background-color: #fff; padding: 15px; border-radius: 5px; border: 1px solid #ddd;'>
                        <h3 style='color: #6c757d;'>Cancelled Appointment Details:</h3>
                        <p style='font-size: 16px;'><strong>📅 Date:</strong> {date:dddd, MMMM dd, yyyy}</p>
                        <p style='font-size: 16px;'><strong>⏰ Time:</strong> {time}</p>
                        <p style='font-size: 16px;'><strong>📍 Address:</strong> {serviceAddress}</p>
                    </div>

                    <p style='font-size: 16px; color: #333;'>If you would like to schedule a new appointment, please visit our website.</p>
                    <p style='font-size: 16px; color: #333;'>If you have any questions, please <a href='mailto:handyman.ca009@gmail.com' style='color: #007BFF;'>contact us</a>.</p>
                    <p style='font-size: 16px; color: #333;'>Thank you for choosing Handyman Services!</p>
                    
                    <hr style='border: none; border-top: 1px solid #ddd;' />
                    <p style='text-align: center; font-size: 14px; color: #777;'>Handyman Services &bull; 📍 Toronto, Canada</p>
                </div>";

                message.Body = new TextPart("html") { Text = emailBody };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
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

    }
    
}
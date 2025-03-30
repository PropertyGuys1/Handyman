using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var appointments = await _context.Appointments
            .Where(a => a.Status == "Pending")
            .OrderBy(a => a.AppointmentDate)
            .ThenBy(a => a.AppointmentTime)
            .ToListAsync();

            return View(appointments);

        }
        // Accept an appointment
        [HttpPost]
        public async Task<ActionResult> AcceptAppointment(int appointmentId, string ProviderId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment != null)
            {
                appointment.Status = "Accepted";
                appointment.ProviderId = ProviderId; // Assign to logged-in provider
                await _context.SaveChangesAsync();

                
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
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
            var appointment = await _context.Appointments.FindAsync(appointmentId);

            if (appointment == null)
            {
                return NotFound("Appointment not found.");
            }

            var appointmentDateTime = appointment.AppointmentDate.Add(appointment.AppointmentTime);
            if (appointmentDateTime < DateTime.Now.AddHours(24))
            {
                return BadRequest("Cannot cancel an appointment within 24 hours of the scheduled time.");
            }

            // Update status and remove provider assignment
            appointment.Status = "Pending";
            appointment.ProviderId = null;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        //public async Task<IActionResult> Profile(string userId)
        //{
        //    if (string.IsNullOrWhiteSpace(userId))
        //    {
        //        return BadRequest("User ID is required.");
        //    }

        //    var userProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);

        //    if (userProfile == null)
        //    {
        //        return NotFound("User profile not found.");
        //    }

        //    return View(userProfile); // ✅ Returns a single Profile object instead of a list
        //}

        public async Task<IActionResult> Profile(string userId)
        {
            var profile = await _context.Profiles
                .Include(p => p.ProviderProfile)
                .ThenInclude(cp => cp.Addresses) // Correctly include the collection of addresses
                .Include(p => p.ProviderProfile.Payments)
                .Include(p => p.ProviderProfile.Appointments)
                .Include(p => p.ProviderProfile.AppointmentFeedbacks)
                .FirstOrDefaultAsync(p => p.UserId == userId); // Use the correct ID type

            var address = _context.Addresses.Where(a => a.userId == userId);
            var payments = _context.Payments.Where(a => a.UserId == userId);
            var appoinments = _context.Appointments.Where(a => a.ProviderId == userId && a.Status == "Completed");
            var totalbalance = 0;
            if (profile == null)
                return NotFound();

            foreach(var item in appoinments)
            {
                totalbalance = totalbalance + item.Cost;
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

        public async Task<IActionResult> EditProfile(string userId)
        {
            var userProfile = _context.Profiles
                .Include(p => p.ProviderProfile)
                .FirstOrDefault(p => p.UserId == userId);

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


        //[HttpPost]
        //public async Task<IActionResult> EditProfile(ProviderProfileViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == model.UserId);
        //    var providerProfile = await _context.ProviderProfiles.FirstOrDefaultAsync(p => p.ProfileId == model.UserId);

        //    if (profile == null || providerProfile == null)
        //    {
        //        return NotFound("Profile not found.");
        //    }

        //    // Update Profile details
        //    profile.FullName = model.FullName;
        //    profile.Email = model.Email;
        //    profile.PhoneNumber = model.PhoneNumber;
        //    profile.Address = model.Address;
        //    providerProfile.Availability = model.Availability;

        //    // Save selected services as a comma-separated string
        //    providerProfile.ServicesOffered = string.Join(",", model.ServicesOffered);

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Profile");
        //}

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

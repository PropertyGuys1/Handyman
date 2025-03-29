using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Handyman.Controllers
{
    [Authorize(Roles ="Provider")]
    public class ProviderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProviderController(ApplicationDbContext context)
        {
            _context = context;
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

            var inProgressAppointments = await _context.Appointments
                .Where(a => a.ProviderId == providerId && a.Status == "InProgress")
                .OrderBy(a => a.AppointmentTime)
                .ToListAsync();

            var completedAppointments = await _context.Appointments
                .Where(a => a.ProviderId == providerId && a.Status == "Completed")
                .OrderByDescending(a => a.AppointmentTime)
                .ToListAsync();

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


        public async Task<IActionResult> Profile(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest("User ID is required.");
            }

            var userProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);

            if (userProfile == null)
            {
                return NotFound("User profile not found.");
            }

            return View(userProfile); // ✅ Returns a single Profile object instead of a list
        }

        [HttpGet("EditProfile/{userId}")]
        public async Task<IActionResult> EditProfile(string userId)
        {
            // Fetch profile and provider profile
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == userId);
            var providerProfile = await _context.ProviderProfiles.FirstOrDefaultAsync(p => p.ProfileId == userId);

            // Fetch service types asynchronously
            var serviceTypes = await _context.ServiceTypes.ToListAsync();

            // Define dropdown options for Availability
            var availabilityOptions = new List<string> { "Full-time", "Part-time", "On-call" };

            // If provider profile does not exist, create a new one
            if (providerProfile == null)
            {
                var newProviderProfile = new ProviderProfile
                {
                    ProfileId = userId,
                    ServicesOffered = "Not specified",
                    Availability = "Not specified",
                    Rating = 5.0m, // Default rating
                    Profile = profile
                };

                var viewModel = new ProviderProfileViewModel
                {
                    Id = profile.Id,
                    UserId = profile.UserId,
                    FullName = profile.FullName,
                    Email = profile.Email,
                    PhoneNumber = profile.PhoneNumber,
                    Address = profile.Address,
                    Active = profile.Active,
                    ServicesOffered = newProviderProfile.ServicesOffered,
                    Availability = newProviderProfile.Availability,
                    Rating = newProviderProfile.Rating,
                    AvailabilityOptions = availabilityOptions,
                    ServiceOptions = serviceTypes  // Add service types to the view model
                };

                return View(viewModel);
            }
            else
            {
                // If provider profile exists, return the existing profile data
                var viewModel = new ProviderProfileViewModel
                {
                    Id = profile.Id,
                    UserId = profile.UserId,
                    FullName = profile.FullName,
                    Email = profile.Email,
                    PhoneNumber = profile.PhoneNumber,
                    Address = profile.Address,
                    Active = profile.Active,
                    ServicesOffered = providerProfile.ServicesOffered,
                    Availability = providerProfile.Availability,
                    Rating = providerProfile.Rating,
                    AvailabilityOptions = availabilityOptions,
                    ServiceOptions = serviceTypes  // Add service types to the view model
                };

                return View(viewModel);
            }
        }


        [HttpPost("EditProfile")]
        public async Task<IActionResult> EditProfile(ProviderProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.UserId == model.UserId);
            var providerProfile = await _context.ProviderProfiles.FirstOrDefaultAsync(p => p.ProfileId == model.UserId);

            if (profile == null || providerProfile == null)
            {
                return NotFound("Profile not found.");
            }

            // Update Profile details
            profile.FullName = model.FullName;
            profile.Email = model.Email;
            profile.PhoneNumber = model.PhoneNumber;
            profile.Address = model.Address;
            providerProfile.Availability = model.Availability;

            // Save selected services as a comma-separated string
            providerProfile.ServicesOffered = string.Join(",", model.ServicesOffered);

            await _context.SaveChangesAsync();

            return RedirectToAction("Profile");
        }



    }
}

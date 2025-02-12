using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Handyman.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public UserController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        public async Task<IActionResult> Profile(string Id)
        {
            var profile = await _context.Profiles
                .Include(p => p.CustomerProfile)
                .ThenInclude(c => c.Address)
                .Include(p => p.CustomerProfile.Appointments)
                .Include(p => p.CustomerProfile.AppointmentFeedbacks)
                .Include(p => p.CustomerProfile.Payments)
                .FirstOrDefaultAsync(p => p.UserId == Id);

            if (profile == null)
                return NotFound();

            var viewModel = new UserProfileViewModel
            {
                Profile = profile,
                CustomerProfile = profile.CustomerProfile,
                Address = profile.CustomerProfile?.Address,
                Appointments = profile.CustomerProfile?.Appointments,
                Feedbacks = profile.CustomerProfile?.AppointmentFeedbacks,
                Payments = profile.CustomerProfile?.Payments
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
                Address = userProfile.Address,
                /*
                Preferences = userProfile.CustomerProfile?.Preferences
            */
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileEditViewModel model, IFormFile? profileImage)
        {
            Console.WriteLine("EditProfile POST action hit."); // Debug statement

            if (ModelState.IsValid)
            {
                // Fetch the user profile from the database
                var profile = await _context.Profiles
                    .FirstOrDefaultAsync(p => p.UserId == model.Id);

                if (profile != null)
                {
                    Console.WriteLine("Profile found: " + profile.FullName); // Debug statement

                    // Update profile properties
                    profile.FullName = model.FullName;
                    profile.Email = model.Email;
                    profile.PhoneNumber = model.PhoneNumber;
                    profile.Address = model.Address;
                    profile.UpdatedAt = DateTime.Now;

                    if (profileImage != null && profileImage.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await profileImage.CopyToAsync(memoryStream);
                            profile.ProfileImage = memoryStream.ToArray(); // Save image data as byte array
                        }
                    }

                    await _context.SaveChangesAsync();
                    Console.WriteLine("Profile saved successfully."); // Debug statement
                    return RedirectToAction("Profile", new { id = model.Id }); // Redirect with user ID
                }
            }
            else
            {
                Console.WriteLine("ModelState is invalid."); // Debug statement
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Error: " + error.ErrorMessage); // Debug statement
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



        // Delete Profile Action
        [HttpPost]
        public IActionResult DeleteProfile(string id)
        {
            var userProfile = _context.Profiles
                .Include(p => p.CustomerProfile)
                .FirstOrDefault(p => p.UserId == id);

            if (userProfile != null)
            {
                _context.Profiles.Remove(userProfile);
                _context.SaveChanges();

                // Redirect to home or login page after deletion
                return RedirectToAction("Index", "Home");
            }

            return NotFound();
        }

        public IActionResult Appointments()
        {
            return View();
        }
    }
}
using System.Security.Claims;
using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;

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
                .Include(p => p.CustomerProfile.Appointments)
                .Include(p => p.CustomerProfile.AppointmentFeedbacks)
                .Include(p => p.CustomerProfile.Payments)
                .FirstOrDefaultAsync(p => p.UserId == id); // Use the correct ID type

            var address = _context.Addresses;

            if (profile == null)
                return NotFound();



            var viewModel = new UserProfileViewModel
            {
                Profile = profile,
                CustomerProfile = profile.CustomerProfile,
                Addresses = address, // Assign the collection of addresses
                Appointments = profile.CustomerProfile?.Appointments,
                Feedbacks = profile.CustomerProfile?.AppointmentFeedbacks,
                Payments = profile.CustomerProfile?.Payments,
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


    }
}
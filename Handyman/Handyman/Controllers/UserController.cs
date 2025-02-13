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
        public async Task<IActionResult> AddEditAddress(string id, int? addressId)
        {
            var model = new AddressViewModel { UserProfileId = id };

            if (addressId.HasValue)
            {
                var address = await _context.Addresses.FindAsync(addressId.Value);
                if (address != null)
                {
                    model.Street = address.Street;
                    model.City = address.City;
                    model.State = address.State;
                    model.PostalCode = address.PostalCode;
                    model.Country = address.Country;
                }
            }

            return View(model);
        }

        // Action to handle the Add/Edit Address form submission
        [HttpPost]
        public async Task<IActionResult> AddEditAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    userId = model.UserProfileId,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    PostalCode = model.PostalCode,
                    Country = model.Country,
                };

                if (model.UserProfileId != null)
                {
                    _context.Addresses.Add(address);
                }
                else
                {
                    _context.Addresses.Update(address);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Profile", new { id = model.UserProfileId });
            }

            return View(model);
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



        public IActionResult Appointments()
        {
            return View();
        }
    }
}
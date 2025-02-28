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

            if (User.Identity.IsAuthenticated)
            {
                // Get the userId from the authenticated user's claims
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                
                addresses = await _context.Addresses
                    .Where(a => a.userId == userId)
                    .ToListAsync();  // Use ToListAsync to execute the query asynchronously
            }
            
            // Create and return the view model with service and addresses
            var model = new ServiceDetailsViewModel
            {
                Service = service,
                Addresses = addresses
            };

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> BookService(int serviceId, int addressId, DateTime date, TimeSpan time, string notes)
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

            // Retrieve the selected address from the database
            var address = await _context.Addresses.FindAsync(addressId);
            if (address == null)
            {
                // If the address is not found, return an error
                TempData["Error"] = "Selected address not found.";
                return RedirectToAction("ServiceDetails", new { id = serviceId });
            }

            // Retrieve the service details
            var service = await _context.Services.Include(s => s.ServiceType).FirstOrDefaultAsync(s => s.Id == serviceId);
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
                Status = "Pending",  // Default status
                ServiceId = serviceId,
                UserId = userId,
                notes = notes
            };

            // Save the booking to the database
            _context.Appointments.Add(booking);
            await _context.SaveChangesAsync();

            // Provide feedback to the user
            TempData["Success"] = "Your booking has been confirmed!";

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

        
    }
}

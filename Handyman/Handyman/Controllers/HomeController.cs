using Handyman.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
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
                .Select(s => s.Name) // Only fetch names for performance
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
        
        public async Task<IActionResult> ServiceDetails(string name)
        {
            var service = await _context.Services
                .Include(s => s.ServiceType)
                .FirstOrDefaultAsync(s => s.Name == name);

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

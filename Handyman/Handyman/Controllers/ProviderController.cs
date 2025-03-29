using Handyman.Data;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Appointments(string id)
        {
            var appointments = _context.Appointments
                //.Include(a => a.Address)
                //.Include(a => a.notes)
                .ToArray();
                
            return View(appointments);  
        }

        public IActionResult Profile(string id)
        {
            var providerProfile = _context.ProviderProfiles
                .Include(p => p.Profile)
                .Include(p => p.ProviderServices)
                .FirstOrDefault(p => p.Profile.UserId == id);

            if (providerProfile == null)
            {
                return NotFound();
            }

            return View(providerProfile);
        }
    }
}

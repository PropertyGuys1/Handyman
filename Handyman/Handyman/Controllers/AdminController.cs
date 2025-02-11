using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Handyman.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var users = _context.UserProfiles.ToList(); // Fetch data from the Users table
            return View(users);
        }

        public async Task<IActionResult> Appointment()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return View(appointments);
        }

        public async Task<IActionResult> Service()
        {
            return View(await _context.Services.Where(s => !s.IsDeleted).ToListAsync());
        }

        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService([Bind("Name,Description,Catagory,Cost")] Service service)
        {
            if (ModelState.IsValid)
            {
                service.Id = Guid.NewGuid();
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Service));
            }
            return View(service);
        }

        public async Task<IActionResult> EditService(Guid? id)
        {
            if (id == null) return NotFound();

            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditService(Guid id, [Bind("Id,Name,Description,Catagory,Cost,IsDeleted")] Service service)
        {
            if (id != service.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Service));
            }
            return View(service);
        }

        [HttpPost, ActionName("DeleteService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                service.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Service));
        }

        private bool ServiceExists(Guid id)
        {
            return _context.Services.Any(e => e.Id == id);
        }

    }

}

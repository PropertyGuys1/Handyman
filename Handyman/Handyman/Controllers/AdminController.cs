using Handyman.Data;
using Handyman.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index()
        {

            var users = await _context.Profiles.Where(s => s.Role == "Customer").ToListAsync(); // Fetch data from the Users table
            return View(users);
        }
        public async Task<IActionResult> ServiceProviders()
        {

            var users = await _context.Profiles.Where(s => s.Role == "Provider").ToListAsync(); // Fetch data from the Users table
            return View(users);
        }
        public async Task<IActionResult> Appointment()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return View(appointments);
        }
        public async Task<IActionResult> ServiceType()
        {
            return View(await _context.ServiceTypes.Where(s => !s.IsDeleted).ToListAsync());
        }
        public async Task<IActionResult> ServiceList(int id)
        {
            var serviceType = await _context.ServiceTypes
                .Include(st => st.Services) // Load related services
                .FirstOrDefaultAsync(st => st.Id == id);

            if (serviceType == null)
            {
                return NotFound();
            }

            return View(serviceType);
        }


        public async Task<IActionResult> Service()
        {
            return View(await _context.Services.Where(s => !s.IsDeleted).ToListAsync());
        }

        public async Task<IActionResult> AddService(int? serviceTypeId)
        {
            ViewBag.ServiceTypes = new SelectList(await _context.ServiceTypes.ToListAsync(), "Id", "Name", serviceTypeId);

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> AddService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("ServiceList",service.ServiceTypeId);

        }

        public async Task<IActionResult> EditService(int? id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            // Populate Service Types with the current service's type pre-selected
            ViewBag.ServiceTypes = new SelectList(_context.ServiceTypes, "Id", "Name", service.ServiceTypeId);

            return View(service);
        }

        [HttpPost]
        public async Task<IActionResult> EditService(Service service)
        {
            _context.Services.Update(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("ServiceList", service.ServiceTypeId);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditService(int id, [Bind("Id,Name,Description,Catagory,Cost,IsDeleted")] Service service)
        //{
        //    //if (id != service.Id) return NotFound();

        //    //if (ModelState.IsValid)
        //    //{
        //    //    try
        //    //    {
        //    //        _context.Update(service);
        //    //        await _context.SaveChangesAsync();
        //    //    }
        //    //    catch (DbUpdateConcurrencyException)
        //    //    {
        //    //        if (!ServiceExists(service.Id)) return NotFound();
        //    //        else throw;
        //    //    }
        //    //    return RedirectToAction(nameof(Service));
        //    //}
        //    //return View(service);
        //    if (!ModelState.IsValid)
        //    {
        //        _context.Services.Update(service);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("ServiceList");
        //    }

        //    // Repopulate dropdown if validation fails
        //    ViewBag.ServiceTypes = new SelectList(_context.ServiceTypes, "Id", "Name", service.ServiceTypeId);

        //    return View(service);
        //}

        [HttpPost, ActionName("DeleteService")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                service.IsDeleted = true; // Soft delete
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Service));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }

    }

}

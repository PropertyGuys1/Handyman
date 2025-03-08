using Handyman.Data;
using Handyman.Data.Entities;
using Handyman.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Handyman.Controllers
{
    [Authorize(Roles ="Admin")]
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
            var appointments = await _context.Appointments
                .Include(a => a.Service)
                .ToListAsync();
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

        public async Task<IActionResult> AddService(int serviceTypeId)
        {
            var serviceTypes = await _context.ServiceTypes
                .Select(st => new SelectListItem
                {
                    Value = st.Id.ToString(),
                    Text = st.Name
                })
                .ToListAsync();

            var viewModel = new AddServiceViewModel
            {
                ServiceTypeId = serviceTypeId, 
                ServiceTypes = serviceTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(AddServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Repopulate dropdown if validation fails
                model.ServiceTypes = await _context.ServiceTypes
                    .Select(st => new SelectListItem
                    {
                        Value = st.Id.ToString(),
                        Text = st.Name
                    })
                    .ToListAsync();

                return View(model);
            }

            var service = new Service
            {
                Name = model.Name,
                Description = model.Description,
                Cost = model.Cost,
                ServiceTypeId = model.ServiceTypeId // Ensure ServiceTypeId is set
            };

            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("ServiceList", model.ServiceTypeId);
        }


        public async Task<IActionResult> AddServiceType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddServiceType(ServiceType ser)
        {

            _context.ServiceTypes.Add(ser); // Do NOT manually set service.Id
            await _context.SaveChangesAsync();
            return RedirectToAction("ServiceType"); // Redirect to service list
        }

        public async Task<IActionResult> EditServiceType(int? id)
        {
            var service = await _context.ServiceTypes.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            // Populate Service Types with the current service's type pre-selected
            ViewBag.ServiceTypes = new SelectList(_context.ServiceTypes, "Id", "Name", service.Id);

            return View(service);
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
        public async Task<IActionResult> EditServiceType(ServiceType service)
        {
            _context.ServiceTypes.Update(service);
            await _context.SaveChangesAsync();
            return RedirectToAction("ServiceList", service.Id);
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
        public async Task<IActionResult> Reports()
        {
            return View();
        }
        public async Task<IActionResult> DownloadAllUsers()
        {
            var users = await _context.Profiles.Where(s => s.Role == "Customer").ToListAsync(); // Get all users from the database

            var csv = new StringBuilder();
            csv.AppendLine("UserId, Customer Name, Email, CreatedDate");

            foreach (var user in users)
            {
                csv.AppendLine($"{user.Id}, {user.FullName}, {user.Email}, {user.CreatedAt}");
            }

            var byteArray = Encoding.UTF8.GetBytes(csv.ToString());
            var fileStream = new System.IO.MemoryStream(byteArray);
            return File(fileStream, "text/csv", "AllUsersReport.csv");
        }

        // Action to download All Service Providers Report
        public async Task<IActionResult> DownloadAllServiceProviders()
        {
            var providers = await _context.Profiles.Where(s => s.Role == "Provider").ToListAsync(); // Get all service providers

            var csv = new StringBuilder();
            csv.AppendLine("ProviderId, Provider Name, Address, ContactNumber");

            foreach (var provider in providers)
            {
                csv.AppendLine($"{provider.Id}, {provider.FullName}, {provider.Address}, {provider.PhoneNumber}");
            }

            var byteArray = Encoding.UTF8.GetBytes(csv.ToString());
            var fileStream = new System.IO.MemoryStream(byteArray);
            return File(fileStream, "text/csv", "AllServiceProvidersReport.csv");
        }

        // Action to download All Appointments Report
        public IActionResult DownloadAllAppointments()
        {
            var appointments = _context.Appointments.ToList(); // Get all appointments

            var csv = new StringBuilder();
            csv.AppendLine("AppointmentId, PersonName, Address, AppointmentDate, AppointmentTime, Status");

            foreach (var appointment in appointments)
            {
                csv.AppendLine($"{appointment.Id}, {appointment.PersonName}, {appointment.Address}, {appointment.AppointmentDate}, {appointment.AppointmentTime}, {appointment.Status}");
            }

            var byteArray = Encoding.UTF8.GetBytes(csv.ToString());
            var fileStream = new System.IO.MemoryStream(byteArray);
            return File(fileStream, "text/csv", "AllAppointmentsReport.csv");
        }

        // Action to download All Appointment Feedbacks Report
        public IActionResult DownloadAllAppointmentFeedbacks()
        {
            var feedbacks = _context.AppointmentFeedbacks.ToList(); // Get all appointment feedbacks

            var csv = new StringBuilder();
            csv.AppendLine("FeedbackId, AppointmentId, CustomerProfileId, Feedback, Rating");

            foreach (var feedback in feedbacks)
            {
                csv.AppendLine($"{feedback.Id}, {feedback.AppointmentId}, {feedback.CustomerProfileId}, {feedback.Feedback}, {feedback.Rating}");
            }

            var byteArray = Encoding.UTF8.GetBytes(csv.ToString());
            var fileStream = new System.IO.MemoryStream(byteArray);
            return File(fileStream, "text/csv", "AllAppointmentFeedbacksReport.csv");
        }
    }

}

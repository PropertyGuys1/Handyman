using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Handyman.Controllers
{
    [Authorize(Roles ="Provider")]
    public class ProviderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();  
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}

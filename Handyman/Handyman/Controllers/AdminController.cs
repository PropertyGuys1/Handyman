using Microsoft.AspNetCore.Mvc;

namespace Handyman.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

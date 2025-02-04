using Microsoft.AspNetCore.Mvc;

namespace Handyman.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

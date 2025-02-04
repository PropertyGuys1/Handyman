using Microsoft.AspNetCore.Mvc;

namespace Handyman.Controllers
{
    public class ProviderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

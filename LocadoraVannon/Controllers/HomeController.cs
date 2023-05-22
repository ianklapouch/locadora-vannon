using Microsoft.AspNetCore.Mvc;

namespace LocadoraVannon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
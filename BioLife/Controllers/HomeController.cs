using Microsoft.AspNetCore.Mvc;

namespace BioLife.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

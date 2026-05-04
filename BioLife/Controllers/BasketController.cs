using Microsoft.AspNetCore.Mvc;

namespace BioLife.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

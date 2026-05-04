using Microsoft.AspNetCore.Mvc;

namespace BioLife.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

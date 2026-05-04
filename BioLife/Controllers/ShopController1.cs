using Microsoft.AspNetCore.Mvc;

namespace BioLife.Controllers
{
    public class ShopController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

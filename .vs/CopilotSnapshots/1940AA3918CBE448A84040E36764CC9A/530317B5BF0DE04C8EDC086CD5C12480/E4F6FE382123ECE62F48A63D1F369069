using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BioLife.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

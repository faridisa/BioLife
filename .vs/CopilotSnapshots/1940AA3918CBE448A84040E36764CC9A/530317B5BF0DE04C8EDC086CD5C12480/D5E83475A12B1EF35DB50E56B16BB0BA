using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BioLife.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index() => View();
    }
}

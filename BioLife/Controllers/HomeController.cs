using BioLife.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly AppDbContext _db;

    public HomeController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _db.Products
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        ViewBag.Products = products;
        return View();
    }
}
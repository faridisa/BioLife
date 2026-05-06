using BioLife.Domain.Entities;
using BioLife.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BioLife.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.ToListAsync();
            return View(products);
        }
    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, IFormFile? ImageFile)
        {
            // 1. Əvvəlcə fayl yoxlanır
            if (ImageFile != null && ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "products");
                Directory.CreateDirectory(uploadsFolder);
                string fileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                    await ImageFile.CopyToAsync(stream);

                model.ImageUrl = "/uploads/products/" + fileName;
            }
            // 2. Fayl yoxdursa URL-i saxla (model.ImageUrl formdan gəlir)

            model.IsActive = true;
            model.CreatedAt = DateTime.UtcNow;
            _db.Products.Add(model);
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = "Məhsul uğurla əlavə edildi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                TempData["ErrorMessage"] = "Məhsul tapılmadı.";
                return RedirectToAction(nameof(Index));
            }

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                string filePath = Path.Combine(_env.WebRootPath, product.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            TempData["SuccessMessage"] = "Məhsul uğurla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
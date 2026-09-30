using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NvsLesson12.Entities;
using NvsLesson12.Models;

namespace NvsLesson12.Controllers
{
    public class NvsProductsController : Controller
    {
        private readonly NvsAppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public NvsProductsController(
            NvsAppDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: NvsProducts
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return View(products);
        }

        // GET: NvsProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: NvsProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name");

            return View();
        }

        // POST: NvsProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Price,SalePrice,Status,Description,CategoryId")] NvsProduct product,
            IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Tạo thư mục wwwroot/Product nếu chưa có
                string folderPath = Path.Combine(
                    _environment.WebRootPath,
                    "Product");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Upload ảnh
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string fileName = Guid.NewGuid().ToString()
                                       + Path.GetExtension(ImageFile.FileName);

                    string filePath = Path.Combine(
                        folderPath,
                        fileName);

                    using (var stream = new FileStream(
                        filePath,
                        FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    product.Image = fileName;
                }

                product.CreatedDate = DateTime.Now;

                _context.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // GET: NvsProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // POST: NvsProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name,Image,Price,SalePrice,Status,Description,CategoryId,CreatedDate")] NvsProduct product,
            IFormFile? ImageFile)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Nếu có ảnh mới thì upload ảnh mới
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        string folderPath = Path.Combine(
                            _environment.WebRootPath,
                            "Product");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        string fileName = Guid.NewGuid().ToString()
                                           + Path.GetExtension(ImageFile.FileName);

                        string filePath = Path.Combine(
                            folderPath,
                            fileName);

                        using (var stream = new FileStream(
                            filePath,
                            FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        product.Image = fileName;
                    }

                    product.CreatedDate = DateTime.Now;

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NvsProductExists(product.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(
                _context.Categories,
                "Id",
                "Name",
                product.CategoryId);

            return View(product);
        }

        // GET: NvsProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: NvsProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                // Xóa ảnh
                if (!string.IsNullOrEmpty(product.Image))
                {
                    string imagePath = Path.Combine(
                        _environment.WebRootPath,
                        "Product",
                        product.Image);

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool NvsProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
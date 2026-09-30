using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NvsLesson12.Entities;
using NvsLesson12.Models;

namespace NvsLesson12.Controllers
{
    public class NvsCategoriesController : Controller
    {
        private readonly NvsAppDbContext _context;

        public NvsCategoriesController(NvsAppDbContext context)
        {
            _context = context;
        }

        // GET: NvsCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NvsCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvscategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);

            if (nvscategory == null)
            {
                return NotFound();
            }

            return View(nvscategory);
        }

        // GET: NvsCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NvsCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Status")] NvsCategory nvscategory)
        {
            if (ModelState.IsValid)
            {
                // Tự động lấy ngày giờ hiện tại
                nvscategory.CreatedDate = DateTime.Now;

                _context.Add(nvscategory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(nvscategory);
        }

        // GET: NvsCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvscategory = await _context.Categories.FindAsync(id);

            if (nvscategory == null)
            {
                return NotFound();
            }

            return View(nvscategory);
        }

        // POST: NvsCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name,Status,CreatedDate")] NvsCategory nvscategory)
        {
            if (id != nvscategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Cập nhật ngày giờ khi chỉnh sửa
                    nvscategory.CreatedDate = DateTime.Now;

                    _context.Update(nvscategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NvsCategoryExists(nvscategory.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(nvscategory);
        }

        // GET: NvsCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nvscategory = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);

            if (nvscategory == null)
            {
                return NotFound();
            }

            return View(nvscategory);
        }

        // POST: NvsCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nvscategory = await _context.Categories.FindAsync(id);

            if (nvscategory != null)
            {
                _context.Categories.Remove(nvscategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool NvsCategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
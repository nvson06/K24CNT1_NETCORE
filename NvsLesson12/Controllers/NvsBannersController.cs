using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NvsLesson12.Entities;
using NvsLesson12.Models;

namespace NvsLesson12.Controllers
{
    public class NvsBannersController : Controller
    {
        private readonly NvsAppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public NvsBannersController(
            NvsAppDbContext context,
            IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Banners.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var banner = await _context.Banners
                .FirstOrDefaultAsync(x => x.Id == id);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,Description,Status")] NvsBanner banner,
            IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                string folder = Path.Combine(
                    _environment.WebRootPath,
                    "Banner");

                Directory.CreateDirectory(folder);

                if (ImageFile != null &&
                    ImageFile.Length > 0)
                {
                    string fileName =
                        Guid.NewGuid() +
                        Path.GetExtension(ImageFile.FileName);

                    string path =
                        Path.Combine(folder, fileName);

                    using var stream =
                        new FileStream(
                            path,
                            FileMode.Create);

                    await ImageFile.CopyToAsync(stream);

                    banner.Image = fileName;
                }

                banner.CreatedDate = DateTime.Now;

                _context.Add(banner);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(banner);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var banner =
                await _context.Banners.FindAsync(id);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,Name,Image,Description,CreatedDate,Status")]
            NvsBanner banner,
            IFormFile? ImageFile)
        {
            if (id != banner.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (ImageFile != null &&
                    ImageFile.Length > 0)
                {
                    string folder = Path.Combine(
                        _environment.WebRootPath,
                        "Banner");

                    Directory.CreateDirectory(folder);

                    string fileName =
                        Guid.NewGuid() +
                        Path.GetExtension(ImageFile.FileName);

                    string path =
                        Path.Combine(folder, fileName);

                    using var stream =
                        new FileStream(
                            path,
                            FileMode.Create);

                    await ImageFile.CopyToAsync(stream);

                    banner.Image = fileName;
                }

                banner.CreatedDate = DateTime.Now;

                _context.Update(banner);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(banner);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var banner =
                await _context.Banners
                .FirstOrDefaultAsync(x => x.Id == id);

            if (banner == null)
                return NotFound();

            return View(banner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner =
                await _context.Banners.FindAsync(id);

            if (banner != null)
            {
                if (!string.IsNullOrEmpty(banner.Image))
                {
                    string path = Path.Combine(
                        _environment.WebRootPath,
                        "Banner",
                        banner.Image);

                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                }

                _context.Banners.Remove(banner);

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
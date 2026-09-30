using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NvsLesson12.Entities;

namespace NvsLesson12.Controllers
{
    public class HomeController : Controller
    {
        private readonly NvsAppDbContext _context;

        public HomeController(NvsAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var banners = await _context.Banners
                .Where(b => b.Status == 1)
                .ToListAsync();

            return View(banners);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
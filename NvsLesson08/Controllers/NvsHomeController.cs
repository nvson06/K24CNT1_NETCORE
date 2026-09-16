using NvsLesson08.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace NvsLesson08.Controllers
{
    public class NvsHomeController : Controller
    {
        private readonly ILogger<NvsHomeController> _logger;

        public NvsHomeController(ILogger<NvsHomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult NvsIndex()
        {
            return View();
        }

        public IActionResult NvsAbout()
        {
            return View();
        }

        public IActionResult NvsPrivacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult NvsError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace NvsLesson2Demo.Controllers
{
    public class NvsProductControlles : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

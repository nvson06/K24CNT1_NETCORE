using Microsoft.AspNetCore.Mvc;

namespace NvsLesson14_Layout_MVC.Areas.NvsAdmins.Controllers
{
    [Area("NvsAdmins")]
    public class NvsDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NvsLesson02Demo.Models;

namespace NvsLesson02Demo.Controllers
{
    public class NvsProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Sơn Nguyễn";
            ViewData["address"] = "Fit NTU";
            TempData["UNI"] = "Trường Đại học Nguyễn Trãi";

            return View();
        }

        // Chi tiết sản phẩm
        public IActionResult GetProduct()
        {
            NvsProduct nvsproduct = new NvsProduct()
            {
                ProductId = "SP01",
                ProductName = "Laptop Dell",
                YearRelease = 2026,
                Price = 25000000
            };

            ViewData["productVD"] = nvsproduct;
            ViewBag.productVB = nvsproduct;

            return View();
        }
    }
}

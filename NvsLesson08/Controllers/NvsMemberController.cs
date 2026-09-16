using NvsLesson08.Models;
using Microsoft.AspNetCore.Mvc;

namespace NvsLesson08.Controllers
{
    public class NvsMemberController : Controller
    {
        public static List<NvsMember> _members = new List<NvsMember>()
        {
            new NvsMember
            {
                NvsMemberId = Guid.NewGuid().ToString(),
                NvsUserName = "SonYV",
                NvsPassword = "Password123!",
                NvsFullName = "NGUYEN VAN SON",
                NvsEmail = "nguyenson@gmail.com"
            },

            new NvsMember
            {
                NvsMemberId = Guid.NewGuid().ToString(),
                NvsUserName = "tranthib",
                NvsPassword = "SecurePass456#",
                NvsFullName = "Trần Thị Bích",
                NvsEmail = "tranthib@outlook.com"
            },

            new NvsMember
            {
                NvsMemberId = Guid.NewGuid().ToString(),
                NvsUserName = "levanc",
                NvsPassword = "MyPassw0rd789",
                NvsFullName = "Lê Văn Cường",
                NvsEmail = "levanc@company.com"
            }
        };
        public IActionResult Index()
        {
            return View(_members);
        }
        [HttpGet]
        public IActionResult NvsCreate()
        {
            var member = new NvsMember();
            return View("Create", member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NvsCreate(NvsMember nvsmember)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", nvsmember);
            }

            if (_members.Any(x => x.NvsMemberId == nvsmember.NvsMemberId))
            {
                ModelState.AddModelError(nameof(nvsmember.NvsMemberId), "Mã thành viên đã tồn tại.");
                return View("Create", nvsmember);
            }

            _members.Add(nvsmember);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult NvsEdit(string id)
        {
            var member = _members.FirstOrDefault(x => x.NvsMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            return View("Edit", member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NvsEdit(string id, NvsMember nvsmember)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", nvsmember);
            }

            var member = _members.FirstOrDefault(x => x.NvsMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            member.NvsUserName = nvsmember.NvsUserName;
            member.NvsPassword = nvsmember.NvsPassword;
            member.NvsFullName = nvsmember.NvsFullName;
            member.NvsEmail = nvsmember.NvsEmail;

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult NvsDetails(string id)
        {
            var member = _members.FirstOrDefault(x => x.NvsMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            return View("Details", member);
        }
        [HttpGet]
        public IActionResult NvsDelete(string id)
        {
            var member = _members.FirstOrDefault(x => x.NvsMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            return View("Delete", member);
        }
        [HttpPost]
        public IActionResult NvsDeleted(string id)
        {
            var member = _members.FirstOrDefault(x => x.NvsMemberId == id);
            if (member is null)
            {
                return NotFound();
            }

            _members.Remove(member);
            return RedirectToAction(nameof(Index));
        }
    }
}

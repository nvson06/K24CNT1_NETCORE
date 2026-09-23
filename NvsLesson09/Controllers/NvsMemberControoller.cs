using Microsoft.AspNetCore.Mvc;
using NvsLesson09.Models.DataModels;
using NvsLesson09.Models.DataModels.DataViewModels;

namespace NvsLesson09.Controllers
{
    public class NvsMemberController : Controller
    {
        private static List<NvsMember> _NvsMember = new List<NvsMember>();

        public IActionResult Index()
        {
            return View(_NvsMember);
        }

        // GET: NvsMember/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvsMember/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NvsMemberRegister NvsMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(NvsMember);
                }

                NvsMember member = new NvsMember
                {
                    NvsMemberId = _NvsMember.Count + 1,
                    NvsUserName = NvsMember.NvsUserName,
                    NvsPassword = NvsMember.NvsPassword,
                    NvsEmail = NvsMember.NvsEmail,
                    NvsPhoneNumber = NvsMember.NvsPhoneNumber,
                    NvsFullname = NvsMember.NvsFullname,
                    NvsBirthday = NvsMember.NvsBirthday
                };

                _NvsMember.Add(member);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(NvsMember);
            }
        }
    }
}
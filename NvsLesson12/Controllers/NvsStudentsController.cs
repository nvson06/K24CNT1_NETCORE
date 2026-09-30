using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NvsLesson12.Entities;
using NvsLesson12.Models;

namespace NvsLesson12.Controllers
{
    public class NvsStudentsController : Controller
    {
        private readonly NvsAppDbContext _context;

        public NvsStudentsController(NvsAppDbContext context)
        {
            _context = context;
        }

        // GET: NvsStudents
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students
                .Include(s => s.StdClass)
                .ToListAsync();

            return View(students);
        }

        // GET: NvsStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students
                .Include(s => s.StdClass)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // GET: Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(
                _context.StdClasses,
                "Id",
                "ClassName");

            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,StudentName,StudentEmail,StudentPhone,StudentAddress,StudentAvatar,StudentBirthday,ClassId")]
            NvsStudent student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClassId"] = new SelectList(
                _context.StdClasses,
                "Id",
                "ClassName",
                student.ClassId);

            return View(student);
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound();

            ViewData["ClassId"] = new SelectList(
                _context.StdClasses,
                "Id",
                "ClassName",
                student.ClassId);

            return View(student);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,StudentName,StudentEmail,StudentPhone,StudentAddress,StudentAvatar,StudentBirthday,ClassId")]
            NvsStudent student)
        {
            if (id != student.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Students.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Students.Any(e => e.Id == student.Id))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ClassId"] = new SelectList(
                _context.StdClasses,
                "Id",
                "ClassName",
                student.ClassId);

            return View(student);
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students
                .Include(s => s.StdClass)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
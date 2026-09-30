using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NvsLesson12.Entities;
using NvsLesson12.Models;

namespace NvsLesson12.Controllers
{
    public class NvsStdClassesController : Controller
    {
        private readonly NvsAppDbContext _context;

        public NvsStdClassesController(NvsAppDbContext context)
        {
            _context = context;
        }

        // GET: NvsStdClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.StdClasses.ToListAsync());
        }

        // GET: NvsStdClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var stdClass = await _context.StdClasses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (stdClass == null)
                return NotFound();

            return View(stdClass);
        }

        // GET: NvsStdClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NvsStdClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,ClassName")] NvsStdClass stdClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stdClass);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(stdClass);
        }

        // GET: NvsStdClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var stdClass = await _context.StdClasses.FindAsync(id);

            if (stdClass == null)
                return NotFound();

            return View(stdClass);
        }

        // POST: NvsStdClasses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,ClassName")] NvsStdClass stdClass)
        {
            if (id != stdClass.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdClassExists(stdClass.Id))
                        return NotFound();

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(stdClass);
        }

        // GET: NvsStdClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var stdClass = await _context.StdClasses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (stdClass == null)
                return NotFound();

            return View(stdClass);
        }

        // POST: NvsStdClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdClass = await _context.StdClasses.FindAsync(id);

            if (stdClass != null)
            {
                _context.StdClasses.Remove(stdClass);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool StdClassExists(int id)
        {
            return _context.StdClasses.Any(x => x.Id == id);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenVanSon_2410900067_exam.Models;

public class NguyenVanSonStudentsController : Controller
{
    private readonly NguyenVanSonStudentContext _context;

    public NguyenVanSonStudentsController(
        NguyenVanSonStudentContext context)
    {
        _context = context;
    }

    // GET: NguyenVanSonStudents
    public async Task<IActionResult> Index()
    {
        var students = await _context.NguyenVanSonStudents
            .AsNoTracking()
            .ToListAsync();

        return View(students);
    }

    // GET: NguyenVanSonStudents/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.NguyenVanSonStudents
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // GET: NguyenVanSonStudents/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: NguyenVanSonStudents/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,NguyenVanSonName,NguyenVanSonGender,NguyenVanSonBirthday,NguyenVanSonEmail,NguyenVanSonPhone,NguyenVanSonActive")]
        NguyenVanSonStudent student)
    {
        if (ModelState.IsValid)
        {
            _context.NguyenVanSonStudents.Add(student);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    // GET: NguyenVanSonStudents/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.NguyenVanSonStudents
            .FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: NguyenVanSonStudents/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        long id,
        [Bind("Id,NguyenVanSonName,NguyenVanSonGender,NguyenVanSonBirthday,NguyenVanSonEmail,NguyenVanSonPhone,NguyenVanSonActive")]
        NguyenVanSonStudent student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.NguyenVanSonStudents.Update(student);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguyenVanSonStudentExists(student.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(student);
    }

    // GET: NguyenVanSonStudents/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.NguyenVanSonStudents
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    // POST: NguyenVanSonStudents/Delete/5
    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long id)
    {
        var student = await _context.NguyenVanSonStudents
            .FindAsync(id);

        if (student != null)
        {
            _context.NguyenVanSonStudents.Remove(student);

            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    private bool NguyenVanSonStudentExists(long id)
    {
        return _context.NguyenVanSonStudents
            .Any(e => e.Id == id);
    }
}
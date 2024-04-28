// StudentsController.cs
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlp.Data;
using sqlp.Models;

namespace sqlp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = _context.Students.Find(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Students students)
        {
            if (id != students.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = _context.Students.FirstOrDefault(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var students = _context.Students.Find(id);
            _context.Students.Remove(students);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public IActionResult Prospector()
        {
            return View();
        }
        public IActionResult Messdetails()
        {
            return View();
        }
        public IActionResult Mess()
        {
            return View();
        }
    }
}

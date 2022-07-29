using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Placement.Models;



namespace Placement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MSContext db;

        public StudentsController(MSContext db)
        {
           this.db = db;
        }

        // GET: Students
        //public async Task<IActionResult> Index()
        //{
        //    if (HttpContext.Session.GetInt32("LoginStudentId") != null)
        //    {
        //        Student s = db.student.Find(HttpContext.Session.GetInt32("LoginStudentId"));
        //        //List<Student> students = new List<Student>();
        //        students.Add(s);
        //        return View(students);
        //        //return RedirectToAction("Details", new { id = s.StudentId });

        //    }

        //    else
        //    {
        //        return View(await db.student.ToListAsync());
        //    }
        //}
        public async Task<IActionResult> Index1()
        {
            if (HttpContext.Session.GetInt32("LoginStudentId") != null)
            {
                Student s = db.student.Find(HttpContext.Session.GetInt32("LoginStudentId"));
                List<Student> students = new List<Student>();
                students.Add(s);
                return RedirectToAction("Index1","students");
                //return RedirectToAction("Details", new { id = s.StudentId });

            }
            else
            {
                return View(await db.student.ToListAsync());
            }
        }

        //public async Task<IActionResult> Loadmore()
        //{
        //    if (HttpContext.Session.GetInt32("LoginStudentId") != null)
        //    {
        //        Student s = db.student.Find(HttpContext.Session.GetInt32("LoginStudentId"));
        //        List<Student> students = new List<Student>();
        //        students.Add(s);
        //        return View(students);
        //        //return RedirectToAction("Details", new { id = s.StudentId });

        //    }
        //    else
        //    {
        //        return View(await db.student.ToListAsync());
        //    }
        //}
        public async Task<IActionResult> Loadmore1()
        {
            if (HttpContext.Session.GetInt32("LoginStudentId") != null)
            {
                Student s = db.student.Find(HttpContext.Session.GetInt32("LoginStudentId"));
                List<Student> students = new List<Student>();
                students.Add(s);
                return RedirectToAction("Index1", "students");
                //return RedirectToAction("Details", new { id = s.StudentId });
            }
            else
            {
                return View(await db.student.ToListAsync());
            }
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(Student obj)
        {
            
            ViewBag.StudentId = HttpContext.Session.GetInt32("LoginStudentId");
            obj.StudentId  = ViewBag.StudentId;
            if (obj.StudentId == null)
            {
                return NotFound();
            }

            var student = await db.student
                .FirstOrDefaultAsync(m => m.StudentId == obj.StudentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,DOB,Native_place,Reg_no,Mobile_No,StudentEmail,Department,SSLC,XII,Diploma,HOA,SA,CGPA,AOI,PassWord,CPassWord")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Add(student);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,DOB,Native_place,Reg_no,Mobile_No,StudentEmail,Department,SSLC,XII,Diploma,HOA,SA,CGPA,AOI,PassWord,CPassWord")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (id == student.StudentId)
            {
                try
                {
                    db.Update(student);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await db.student
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await db.student.FindAsync(id);
            db.student.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index1","Students");
        }

        private bool StudentExists(int id)
        {
            return db.student.Any(e => e.StudentId == id);
        }

        [HttpGet]
        public IActionResult SearchForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserIndex(string SearchPhrase)     //User Post method
        {
            return View(db.student .Where(i => i.Reg_no.Contains(SearchPhrase)).ToList());

        }




    }
}



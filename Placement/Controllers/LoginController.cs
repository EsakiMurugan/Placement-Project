using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Placement.Models;
using System.Linq;

namespace Placement.Controllers
{
    public class LoginController : Controller
    {
        private readonly MSContext db;
        private readonly ISession session;
        public LoginController(MSContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            session = httpContextAccessor.HttpContext.Session;
        }

        public IActionResult SLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SLogin(Student obj)
        {
            var result = (from i in db.student
                          where i.StudentId == obj.StudentId && i.PassWord == obj.PassWord
                          select i).SingleOrDefault();
            ViewBag.StudentId = obj.StudentId;
            HttpContext.Session.SetInt32("LoginStudentId", obj.StudentId);
            if (result != null)
            {
                HttpContext.Session.SetString("StudentName", result.StudentName);
                return RedirectToAction("SLoginView","Login");
            }
            else
            {
                return View();
            }
        }
        public IActionResult SRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SRegister(Student obj1)
        {
            ViewBag.StudentId = obj1.StudentId;
            if (obj1.StudentId != null)
            {
                db.student.Add(obj1);
                db.SaveChanges();
                HttpContext.Session.SetInt32("StudentId", obj1.StudentId);
                return View();
            }
            else { return View(); }
           
        }
        public IActionResult ALogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ALogin(Admin obj)
        {
            var result = (from i in db.admin
                          where i.FacultyId == obj.FacultyId && i.PassWord == obj.PassWord
                          select i).SingleOrDefault();
            if (result != null)
            {
                HttpContext.Session.SetString("FacultyName", result.FacultyName);
                return RedirectToAction("ALoginView","Login");
              
            }
            else
            {
                return View();
            }
        }
        public IActionResult ARegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ARegister(Admin obj)
        {
            ViewBag.FacultyId = obj.FacultyId;
            if(obj.FacultyId!= null)
            {
                db.admin.Add(obj);
                db.SaveChanges();
                HttpContext.Session.SetInt32("FacultyId", obj.FacultyId);
                return View();
            }
            else
            {
                return View();
            }
           
            
        }
        public IActionResult ALoginView()
        {
            return View();
        }
        public IActionResult SLoginView()
        {
            return View();
            
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }

}

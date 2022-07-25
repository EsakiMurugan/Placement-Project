using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Placement.Models;
using System.Linq;

namespace Placement.Controllers
{
    public class NoDirectAccessAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var canAcess = false;

            // check the refer
            var referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                var rUri = new System.UriBuilder(referer).Uri;
                var req = filterContext.HttpContext.Request;
                if (req.Host.Host == rUri.Host && req.Host.Port == rUri.Port && req.Scheme == rUri.Scheme)
                {
                    canAcess = true;
                }
            }

            // ... check other requirements

            if (!canAcess)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index", area = "" }));
            }
        }
    }
    public class LoginController : Controller
    {
        private readonly MSContext db;
        private readonly ISession session;
        public LoginController(MSContext db, IHttpContextAccessor httpContextAccessor)
        {
            this.db = db;
            session = httpContextAccessor.HttpContext.Session;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult SLogin()
        {
            return View();
        }
        [HttpPost]
        [NoDirectAccess]
        public IActionResult SLogin(Student obj)
        {
            var result = (from i in db.student
                          where i.StudentId == obj.StudentId && i.PassWord == obj.PassWord
                          select i).SingleOrDefault();
           
            ViewBag.StudentId = obj.StudentId;
            HttpContext.Session.SetInt32("LoginStudentId", obj.StudentId);
            ViewBag.StudentId = obj.StudentId;
            HttpContext.Session.SetInt32("ApplyStudentId", obj.StudentId);
            if (result != null)
            {   HttpContext.Session.SetString("PassWord",obj.PassWord);
                HttpContext.Session.SetString("StudentName", result.StudentName);
                return RedirectToAction("Details","Students");
               
            }
            else
            {
                HttpContext.Session.SetString("LoginPassWord", obj.PassWord);
                return View();
            }
        }
        public IActionResult SRegister()
        {
            return View();
        }
        [HttpPost]
        [NoDirectAccess]
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
        [NoDirectAccess]
        public IActionResult ALogin(Admin obj)
        {
            var result = (from i in db.admin
                          where i.FacultyId == obj.FacultyId && i.PassWord == obj.PassWord
                          select i).SingleOrDefault();
            ViewBag.PassWord = obj.PassWord;
            HttpContext.Session.SetString("ALoginPassWord", obj.PassWord);
            //ViewBag.FacultyId = obj.FacultyId;
            //HttpContext.Session.SetInt32("AFacultyId", obj.FacultyId);
            if (result != null)
            {
                HttpContext.Session.SetString("FacultyName", result.FacultyName);
                return RedirectToAction("Index","Companies");
              
            }
            else
            {
                HttpContext.Session.SetString("ALoginPassWord", obj.PassWord);
                return View();
            }
        }
        public IActionResult ARegister()
        {
            return View();
        }
        [HttpPost]
        [NoDirectAccess]
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
        [NoDirectAccess]
        public IActionResult Popup()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoComplete.Models;

namespace AutoComplete.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DatabaseContext db = new DatabaseContext();
            return View(db.Students);
        }

        [HttpPost]
        public ActionResult Index(string searchTerm)
        {
            DatabaseContext db = new DatabaseContext();
            List<Student> students;
            if (string.IsNullOrEmpty(searchTerm))
            {
                students = db.Students.ToList();
            }
            else
            {
                students = db.Students
                    .Where(s => s.Name.StartsWith(searchTerm)).ToList();
            }
            return View(students);
        }

        public JsonResult GetStudents(string term)
        {
            DatabaseContext db = new DatabaseContext();
            List<string> students = db.Students.Where(s => s.Name.StartsWith(term))
                .Select(x => x.Name).ToList();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
    }
}
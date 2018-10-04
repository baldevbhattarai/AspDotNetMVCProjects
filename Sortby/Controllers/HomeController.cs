using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sortby.Models;
using PagedList;
namespace Sortby.Controllers
{
    public class HomeController : Controller
    {
        private SampleDBContext db = new SampleDBContext();

        // GET: Home
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            ViewBag.NameSort = String.IsNullOrEmpty(sortBy) ? "Name desc" : "";
            ViewBag.GenderSort = sortBy == "Gender" ? "Gender desc" : "Gender";

            var employees = db.Employees.AsQueryable();

            if (searchBy == "Gender")
            {
                employees = employees.Where(x => x.Gender == search || search == null);
            }
            else
            {
                employees = employees.Where(x => x.FullName.StartsWith(search) || search == null);
            }

            switch (sortBy)
            {
                case "Name desc":
                    employees = employees.OrderByDescending(x => x.FullName);
                    break;
                case "Gender desc":
                    employees = employees.OrderByDescending(x => x.Gender);
                    break;
                case "Gender":
                    employees = employees.OrderBy(x => x.Gender);
                    break;
                default:
                    employees = employees.OrderBy(x => x.FullName);
                    break;
            }

            return View(employees.ToPagedList(page ?? 1, 3));
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<int> employeeIdsToDelete)
        {
            //db.Employees.Where(x => employeeIdsToDelete.Contains(x.Id)).ToList().ForEach(db.Employees.DeleteObjects);
            foreach(int id in employeeIdsToDelete)
            {
                Employee employee = db.Employees.Single(x => x.Id == id);
                db.Employees.Remove(employee);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Gender,Age,HireDate,EmailAddress,Salary,PersonalWebSite,Photo,AlternateText")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Gender,Age,HireDate,EmailAddress,Salary,PersonalWebSite,Photo,AlternateText")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace UsingBusinessObjectAsModel.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer =
            new EmployeeBusinessLayer();

            List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
          return View();
        }
        [HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        public ActionResult Create(string name, string gender, string city, DateTime dateofbirth)
        {
            Employee employee = new Employee();
            // Retrieve form data using form collection
            //employee.Name = formCollection["Name"];
            //employee.Gender = formCollection["Gender"];
            //employee.City = formCollection["City"];
            //employee.DateOfBirth =
            //    Convert.ToDateTime(formCollection["DateOfBirth"]);

            // we can easily do like..
            employee.Name = name;
            employee.Gender = gender;
            employee.City = city;
            employee.DateOfBirth = dateofbirth;
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
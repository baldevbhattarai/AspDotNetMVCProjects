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
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
          return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Employee employee = new Employee();
            UpdateModel(employee);
            EmployeeBusinessLayer employeeBusinessLayer =
                new EmployeeBusinessLayer();

            employeeBusinessLayer.AddEmmployee(employee);
            return RedirectToAction("Index");
        }
    }
}
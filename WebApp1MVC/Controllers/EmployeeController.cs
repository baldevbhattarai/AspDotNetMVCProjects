using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1MVC.Models;

namespace WebApp1MVC.Controllers
{
    public class EmployeeController : Controller
    {
        
        public ActionResult Index(int departmentId)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            List<Employee> employees = employeeContext.employees.Where(emp=>emp.DepartmentId==departmentId).ToList();

            return View(employees);
        }
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
           Employee employee =  employeeContext.employees.Single(x=>x.EmployeeId==id);

            return View(employee);
        }
    }
}
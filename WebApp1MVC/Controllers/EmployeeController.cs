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
        // GET: Employee
        public ActionResult Details()
        {
            Employee employee = new Employee()
            {

                EmployeeId = 101,
                Name = "John",
                Gender = "Male",
                City = "London"
            };

            
            return View(employee);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //ViewBag.Countries = new List<string>()
            ViewData["Countries"] = new List<string>()
            {
                "Nepal",
                "India",
                "USA",
                "Japan"
            };
            return View();
        }
    }
}
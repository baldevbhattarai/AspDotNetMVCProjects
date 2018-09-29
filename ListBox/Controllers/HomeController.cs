using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ListBox.Models;
using System.Text;

namespace ListBox.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            SampleDBContext db = new SampleDBContext();
            List<SelectListItem> listSelectListItems = new List<SelectListItem>();

            foreach (City city in db.Cities)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = city.Name,
                    Value = city.ID.ToString(),
                    Selected = city.IsSelected
                };
                listSelectListItems.Add(selectList);
            }

            ViewModel citiesViewModel = new ViewModel()
            {
                Cities = listSelectListItems
            };

            return View(citiesViewModel);
        }

        [HttpPost]
        public string Index(IEnumerable<string> selectedCities)
        {
            if (selectedCities == null)
            {
                return "No cities selected";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You selected - " + string.Join(",", selectedCities));
                return sb.ToString();
            }
        }
    }
}
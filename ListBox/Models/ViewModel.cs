using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListBox.Models
{
    public class ViewModel
    {
        public IEnumerable<string> SelectedCities { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
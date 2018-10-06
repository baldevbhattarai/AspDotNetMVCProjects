using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Sortby.Common;
namespace Sortby.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }
    public class EmployeeMetaData
    {
        
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        [StringLength(10, MinimumLength = 5)]
        [Required]
        public string FullName { get; set; }
        public string Gender { get; set; }
        [Range(1, 100)]
        public Nullable<int> Age { get; set; }

        [DateRange("01/01/2000")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> HireDate { get; set; }
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        public string EmailAddress { get; set; }
        public Nullable<int> Salary { get; set; }
        public string PersonalWebSite { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }
    }
}
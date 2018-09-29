using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CustomHtmlHelperDemo.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }

    public class EmployeeMetaData
    {
        //If you want "FullName" to be displayed as "Full Name", 
        //use DisplayAttribute or DisplayName attribute.
        //DisplayName attribute is in System.ComponentModel namespace.
        //[DisplayAttribute(Name="Full Name")]
        //[Display(Name = "Full Name")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        //To get only the date part in a datetime data type
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DisplayFormatAttribute(DataFormatString="{0:d}")]

        //To get time in 24 hour notation
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]

        //To get time in 12 hour notation with AM PM
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? HireDate { get; set; }

        // If gender is NULL, "Gender not specified" text will be displayed.
        [DisplayFormat(NullDisplayText = "Gender not specified")]
        public string Gender { get; set; }


        // Display mailto hyperlink
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        // Display currency symbol. For country specific currency, set 
        // culture using globalization element in web.config. 
        // For Great Britain Pound symbol
        // <globalization culture="en-gb"/>
        //If you don't want to display a column use ScaffoldColumn attribute.
        //This only works when you use @Html.DisplayForModel() helper
        [ScaffoldColumn(false)]
        [DataType(DataType.Currency)]
        public int? Salary { get; set; }

        // Generate a hyperlink
        [DataType(DataType.Url)]
        public string PersonalWebSite { get; set; }
     
    }
}
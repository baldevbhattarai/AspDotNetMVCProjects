﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        public Nullable<System.DateTime> HireDate { get; set; }
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        public string EmailAddress { get; set; }
        public Nullable<int> Salary { get; set; }
        public string PersonalWebSite { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }
    }
}
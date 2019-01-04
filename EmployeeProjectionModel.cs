using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL_Employee.Models
{
    public class EmployeeProjectionModel
    {
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }
        [Display(Name = "Employee Name")]
        public string EmplpoyeeName { get; set; }
        [Display(Name = "Employee Gender")]
        public string EmployeeGender { get; set; }
        [Display(Name = "Employee Image")]
        public string EmployeeImageAddress { get; set; }
    }
}
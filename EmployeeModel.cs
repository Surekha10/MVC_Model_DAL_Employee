using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Model_DAL_Employee.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }
        [Display(Name ="Employee Name")]
        [Required(ErrorMessage = "*")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Too Short Name")]
        public string EmployeeName { get; set; }
        [Display(Name = ("Employee City"))]
        [Required(ErrorMessage = "*")]
        public string EmployeeCity { get; set; }
        [Display(Name = ("Employee Email ID"))]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Invalid Format")]
        public string EmployeeEmail { get; set; }
        [Display(Name = ("Employee Password"))]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string EmployeePassword { get; set; }
        [Display(Name = ("Employee Gender"))]
        [Required(ErrorMessage = "*")]
        public string EmployeeGender { get; set; }
        public string EmpoyeeImageAddress { get; set; }
        [Display(Name = ("Employee Image"))]
        [Required(ErrorMessage = "*")]
        public HttpPostedFileBase EmployeeImageFile { get; set; }
    }
}
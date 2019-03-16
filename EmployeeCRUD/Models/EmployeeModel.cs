using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCRUD.Models
{
    public class EmployeeModel
    {

        public Int64 ID { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name Required")]
        public string EmpName { get; set; }

        [Display(Name = "Employee Code")]
        [Required(ErrorMessage = "Employee Code Required")]
        public string EmpCode { get; set; }

        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Address1 Required")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address2 Required")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "PinCode Required")]
        public string Pincode { get; set; }

        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter your FName")]
        public string inputFName { get; set; }
        [Required(ErrorMessage = "Please enter your SurName")]
        public string inputLName { get; set; }
        [Required(ErrorMessage = "ID is mandatory")]
        [Key]
        public int inputId { get; set; }
        [Required(ErrorMessage = "Please Enter valid password")]
        public string inputPassword { get; set; }
        [Required(ErrorMessage ="Enter Your Phone Number")]
        public string inputPhone { get; set; }
        [Required(ErrorMessage = "Please enter your Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",
            ErrorMessage = "Your email address is not in valid format." +
            "Example of correct format: abcd.pqr@xyz.xyz")]
        public string inputEmail { get; set; }
        [Required(ErrorMessage ="Please Select Type")]
        public string inputType { get; set; }


    }
}
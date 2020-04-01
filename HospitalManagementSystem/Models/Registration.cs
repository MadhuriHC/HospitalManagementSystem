using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Please enter your Email ID")]
        [Key]
        [EmailAddress]
        [Display(Name = "Email ID *")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [StringLength(30,MinimumLength =8)]
        [Display(Name = "Password *")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your Category")]
        [Display(Name = "Category *")]
        public string Category { get; set; }
    }
}
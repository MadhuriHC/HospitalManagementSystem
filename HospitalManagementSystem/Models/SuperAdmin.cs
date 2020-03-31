using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class SuperAdmin
    {
        [Key]
        public int SID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name *")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Middle Name *")]
        public string MiddleName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; }
        [Required]
        [Phone]
        [Display(Name = "Contact No. *")]
        public long Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email ID *")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password *")]
        public string Password { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "First Name *")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your Last Name")]
        [Display(Name = "Last Name *")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter your Email ID")]
        [EmailAddress]
        [Display(Name = "Email ID *")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Contact No.")]
        [Display(Name = "Contact No. *")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "Please enter your Staff Category")]
        [Display(Name = "Staff Category *")]
        public string SCategory { get; set; }
    }
}
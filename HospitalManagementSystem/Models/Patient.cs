using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name *")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name *")]
        public string Gender { get; set; }
        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth *")]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email ID *")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contact No. *")]
        public long Phone { get; set; }
        [Required]
        [Display(Name = "Blood Group *")]
        public string BloodGroup { get; set; }
        [Required]
        [Display(Name = "Status *")]
        public int Status { get; set; }
        public string Photo { get; set; }

        public Nullable<int> DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
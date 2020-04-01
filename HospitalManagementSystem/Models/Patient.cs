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
        [Required(ErrorMessage = "Please enter First Name")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name *")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter Last Name")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please select Gender")]
        [DataType(DataType.Text)]
        [Display(Name = "Gender *")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Please select Date of Birth")]
        [DisplayFormat(DataFormatString = "{mm-dd-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth *")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please enter Email ID")]
        [EmailAddress]
        [Display(Name = "Email ID *")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter Contact No.")]
        [Display(Name = "Contact No. *")]
        public long Phone { get; set; }
        [Required(ErrorMessage = "Please enter Blood Group")]
        [Display(Name = "Blood Group *")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Please enter Patient's Status")]
        [Display(Name = "Status *")]
        public int Status { get; set; }
        public string Photo { get; set; }

        public Nullable<int> DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
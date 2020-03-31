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
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Gender { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public long Phone { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        public int Status { get; set; }
        public string Photo { get; set; }

        public Nullable<int> DoctorID { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
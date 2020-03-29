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
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
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
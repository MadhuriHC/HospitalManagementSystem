using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace HMSProject.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public string BloodGroup { get; set; }
        public int Status { get; set; }
        //public Image Photo { get; set; }
    }
}
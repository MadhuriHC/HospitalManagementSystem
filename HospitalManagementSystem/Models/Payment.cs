using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public Nullable<int> PatientID { get; set; }
        [Required]
        [Display(Name ="Payable Amount")]
        public double PayableAmount { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:dd-mm-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string PaymentMethod { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Status { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
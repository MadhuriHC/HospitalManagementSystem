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
        [Required(ErrorMessage = "Please enter Payable Amount")]
        [Display(Name ="Payable Amount *")]
        public double PayableAmount { get; set; }
        [Required(ErrorMessage = "Please enter Payment Date")]
        [DisplayFormat(DataFormatString = "{mm-dd-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Payment Date *")]
        public DateTime PaymentDate { get; set; }
        [Required(ErrorMessage = "Please enter Payment Method")]
        [DataType(DataType.Text)]
        [Display(Name = "Payment Method *")]
        public string PaymentMethod { get; set; }
        [Required(ErrorMessage = "Please enter Payment Status")]
        [DataType(DataType.Text)]
        [Display(Name = "Payment Status *")]
        public string Status { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
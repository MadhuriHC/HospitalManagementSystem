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
        public int PaymemntID { get; set; }
        public Nullable<int> PatientID { get; set; }
        [Required]
        public double PayableAmount { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:dd-mm-yyyy}")]
        public DateTime PaymentDate { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public string Status { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
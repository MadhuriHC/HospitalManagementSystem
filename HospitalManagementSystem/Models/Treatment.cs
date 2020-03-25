using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public partial class Treatment
    {
        [Key]
        public int TreatemntID { get; set; }
        public Nullable<int> PatientID { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Prescription { get; set; }
        public virtual Patient Patient { get; set; }
    }
}

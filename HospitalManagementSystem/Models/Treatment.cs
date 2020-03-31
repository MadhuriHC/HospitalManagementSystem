using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class Treatment
    {
        [Key]
        public int TreatmentID { get; set; }

        public Nullable<int> PatientID { get; set; }
        [Required]
        public DateTime CheckupDate { get; set; }
        [Required]
        public string Symptoms { get; set; }
        [Required]
        public string Diagnosis { get; set; }
        [Required]
        public string Medicine { get; set; }
        [Required]
        public string Doses { get; set; }
        [Required]
        public string BeforeMeal { get; set; }
        public string Advice { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
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
        [Required(ErrorMessage = "Please enter Checkup Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Checkup Date *")]
        public DateTime CheckupDate { get; set; }
        [Required(ErrorMessage = "Please enter Symptoms")]
        [Display(Name = "Symptoms *")]
        public string Symptoms { get; set; }
        [Required(ErrorMessage = "Please enter Diagnosis")]
        [Display(Name = "Diagnosis *")]
        public string Diagnosis { get; set; }
        [Required(ErrorMessage = "Please enter Medicine")]
        [Display(Name = "Medicine *")]
        public string Medicine { get; set; }
        [Required(ErrorMessage = "Please select Doses")]
        [Display(Name = "Doses *")]
        public string Doses { get; set; }
        [Required(ErrorMessage = "Please select Before Meal")]
        [DataType(DataType.Text)]
        [Display(Name = "Before Meal *")]
        public string BeforeMeal { get; set; }
        public string Advice { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
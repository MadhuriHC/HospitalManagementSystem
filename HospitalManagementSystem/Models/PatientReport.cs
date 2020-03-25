using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    public class PatientReport
    {
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
        public Treatment treatment { get; set; }
    }
}
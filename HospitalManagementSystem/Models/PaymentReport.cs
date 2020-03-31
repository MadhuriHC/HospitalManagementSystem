using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    public class PaymentReport
    {
        public Patient patient { get; set; }
        public Payment payment { get; set; }
    }
}
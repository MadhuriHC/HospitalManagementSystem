using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HospitalManagementSystem.Models
{
    public class HMSDbContext:DbContext
    {
        public HMSDbContext() : base("HMSDatabase")
        {

        }
        public DbSet<GuestResponse> GuestResponses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<SuperAdmin> Admin { get; set; }
        public DbSet<Staff> Staffs { get; set; }
          
        
    }
}
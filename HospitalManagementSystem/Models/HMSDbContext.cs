using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HMSProject.Models
{
    public class HMSDbContext:DbContext
    {
        public HMSDbContext() : base("HMSDbContext")
        {

        }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; }
        DbSet<SuperAdmin> Admin { get; set; }
        DbSet<Staff> Staffs { get; set; }
    }
}
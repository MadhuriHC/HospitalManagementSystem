using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;
using System.Data.Entity;

namespace HospitalManagementSystem.Controllers
{
    public class PatientReportController : Controller
    {
        private HMSDbContext db = new HMSDbContext();
        // GET: PatientReport
        public ActionResult ExistingPatientReport()
        {
            using (db)
            {
                List<Patient> patient = db.Patients.ToList();
                List<Doctor> doctor = db.Doctors.ToList();
                List<Treatment> treatment = db.Treatments.ToList();

                var PatientReport = from p in patient
                                    join d in doctor on p.DoctorID equals d.DoctorID into table1
                                    from d in table1.ToList()
                                    join t in treatment on p.PatientID equals t.PatientID into table2
                                    from t in table2.ToList()
                                    select new PatientReport
                                    {
                                        patient = p,
                                        doctor = d,
                                        treatment = t
                                    };
                return View(PatientReport);
            }
        }
    }
}
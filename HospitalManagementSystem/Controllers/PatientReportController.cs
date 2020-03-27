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

        public ActionResult PatientList()
        {
            //int id= (int)RouteData.Values["did"];
            List<Patient> patient = db.Patients.ToList();
            var PatientList = from p in patient where p.DoctorID == 1 select new PatientReport { patient = p };
            return View(PatientList);
        }

        public ActionResult NewPatientReport(int? id)
        {
            ViewBag.PatientID = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPatientReport([Bind(Include = "TreatemntID,PatientID,CheckupDate,Symptoms,Diagnosis,Medicine,Doses,BeforeMeal")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Treatments.Add(treatment);
                db.SaveChanges();
                return RedirectToAction("PatientList");
            }

            // ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", treatment.PatientID);
            return View(treatment);
        }

        // GET: PatientReport
        public ActionResult ExistingPatientReport(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Treatment tt = db.Treatments.Find(id);
            if (tt == null)
            {
                return HttpNotFound();
            }
            else
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
                                        where t.PatientID == id
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

        // GET: Treatments/Edit/5
        public ActionResult EditExistingReport(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", treatment.PatientID);
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditExistingReport([Bind(Include = "TreatemntID,PatientID,CheckupDate,Symptoms,Diagnosis,Medicine,Doses,BeforeMeal")] Treatment treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatientList");
            }
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", treatment.PatientID);
            return View(treatment);
        }
    }
}
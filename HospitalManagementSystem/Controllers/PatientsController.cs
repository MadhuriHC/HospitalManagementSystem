using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class PatientsController : Controller
    {
        private HMSDbContext db = new HMSDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FirstName,LastName,DOB,Email,Phone,BloodGroup,Status,Photo,Gender")] Patient patient,HttpPostedFileBase postedFile)
        {
            string filename = System.IO.Path.GetFileName(postedFile.FileName);
            string filepath = "~/Uploads/PatientImages/" + filename;
            postedFile.SaveAs(Server.MapPath(filepath));
            if (ModelState.IsValid)
            {
                db.Patients.Add(new Patient
                {
                    FirstName=patient.FirstName,
                    LastName=patient.LastName,
                    DOB=patient.DOB,
                    Email=patient.Email,
                    Phone=patient.Phone,
                    BloodGroup=patient.BloodGroup,
                    Status=patient.Status,
                    Photo=filepath
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FirstName,LastName,DOB,Email,Phone,BloodGroup,Status,Photo,Gender")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult PatientList()
        {
            //int id= (int)RouteData.Values["did"];
            List<Patient> patient = db.Patients.ToList();
            var PatientList = from p in patient where p.DoctorID == 1 select new PatientReport { patient = p };
            return View(PatientList);
        }

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

        public ActionResult PatientReportSummary(int? id)
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

        public ActionResult PrintableReportSummary(int? id1, int? id2, int? n)
        {
            if (n == 1)
                ViewBag.n = 1;
            else
                ViewBag.n = 2;
            using (db)
            {
                List<Patient> patient = db.Patients.ToList();
                List<Doctor> doctor = db.Doctors.ToList();
                List<Treatment> treatment = db.Treatments.ToList();

                if (id1 != null && id2 == null)
                {
                    var PatientReport = from p in patient
                                        join d in doctor on p.DoctorID equals d.DoctorID into table1
                                        from d in table1.ToList()
                                        join t in treatment on p.PatientID equals t.PatientID into table2
                                        from t in table2.ToList()
                                        where t.PatientID == id1
                                        select new PatientReport
                                        {
                                            patient = p,
                                            doctor = d,
                                            treatment = t
                                        };
                    return View(PatientReport);
                }
                else
                {
                    var PatientReport = from p in patient
                                        join d in doctor on p.DoctorID equals d.DoctorID into table1
                                        from d in table1.ToList()
                                        join t in treatment on p.PatientID equals t.PatientID into table2
                                        from t in table2.ToList()
                                        where t.PatientID == id1 & t.TreatmentID == id2
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
}

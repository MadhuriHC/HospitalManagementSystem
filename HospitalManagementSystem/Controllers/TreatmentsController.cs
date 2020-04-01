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
    public class TreatmentsController : Controller
    {
        private HMSDbContext db = new HMSDbContext();

        // GET: Treatments
        public ActionResult Index()
        {
            var treatments = db.Treatments.Include(t => t.Patient);
            return View(treatments.ToList());
        }

        // GET: Treatments/Details/5
        public ActionResult Details(int? id,int? l)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.layout = l;
            return View(treatment);
        }

        // GET: Treatments/Create
        public ActionResult Create(int? id,int? l)
        {
           ViewBag.PatientID = id;
            ViewBag.layout = l;
            //ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            return View();
        }

        // POST: Treatments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentID,PatientID,CheckupDate,Symptoms,Diagnosis,Medicine,Doses,BeforeMeal,Advice")] Treatment treatment,FormCollection fc)
        {
            //if (ModelState.IsValid)
            //{
				treatment.Doses = fc["Doses"];
                treatment.BeforeMeal = fc["RbBeforeMeal"];
            treatment.CheckupDate.ToString("mm-dd-yyyy");
            db.Treatments.Add(treatment);
                db.SaveChanges();
                return RedirectToAction("ExistingPatientReport", "Patients", new { id = treatment.PatientID ,l=1});
            //}

           // ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", treatment.PatientID);
            //return View(treatment);
        }

        // GET: Treatments/Edit/5
        public ActionResult Edit(int? id,string doses,string bm, DateTime cd,int? l)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            if (doses.Equals("1-0-0"))
                ViewBag.n = 1;
            else if (doses.Equals("0-1-0"))
                ViewBag.n = 2;
			else if (doses.Equals("0-0-1"))
                ViewBag.n = 3;
			else if (doses.Equals("1-1-0"))
                ViewBag.n = 4;
			else if (doses.Equals("1-0-1"))
                ViewBag.n = 5;
			else if (doses.Equals("0-1-1"))
                ViewBag.n = 6;
			else if (doses.Equals("1-1-1"))
                ViewBag.n = 7;

            if(bm.Equals("Yes"))
                ViewBag.n = 1;
            else
                ViewBag.n = 0;

            ViewBag.c = cd.ToShortDateString();
            ViewBag.layout = l;
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", treatment.PatientID);
            return View(treatment);
        }

        // POST: Treatments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentID,PatientID,CheckupDate,Symptoms,Diagnosis,Medicine,Doses,BeforeMeal,Advice")] Treatment treatment,FormCollection fc)
        {
            //if (ModelState.IsValid)
            //{
            treatment.Doses = fc["Doses"];
            treatment.BeforeMeal = fc["RbBeforeMeal"];
                db.Entry(treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ExistingPatientReport", "Patients", new { id = treatment.PatientID ,l=1});
            //}

            //ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", treatment.PatientID);
            //return View(treatment);
        }

        // GET: Treatments/Delete/5
        public ActionResult Delete(int? id,int? l)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treatment treatment = db.Treatments.Find(id);
            if (treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.layout = l;
            return View(treatment);
        }

        // POST: Treatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Treatment treatment = db.Treatments.Find(id);
            int? PID = treatment.PatientID;
            db.Treatments.Remove(treatment);
            db.SaveChanges();
            return RedirectToAction("ExistingPatientReport", "Patients", new { id = PID ,l=1});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

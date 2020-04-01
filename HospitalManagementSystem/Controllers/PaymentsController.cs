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
    public class PaymentsController : Controller
    {
        private HMSDbContext db = new HMSDbContext();

        // GET: Payments
        public ActionResult PaymentReport(int? id,int? l)
        {
            using (db)
            {
                List<Patient> patient = db.Patients.ToList();
                List<Payment> payment = db.Payments.ToList();

                var PaymentReport = from p1 in patient
                                    join p2 in payment on p1.PatientID equals p2.PatientID into table1
                                    from p2 in table1.ToList()
                                    where p2.PatientID == id
                                    select new PaymentReport
                                    {
                                        patient = p1,
                                        payment = p2
                                    };
                ViewBag.layout = l;
                return View(PaymentReport);
            }

            //var payments = db.Payments.Include(p => p.Patient);
            //return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id, int? l)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.layout = l;
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create(int? id, int? l)
        {
            // ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName");
            ViewBag.PatientID = id;
            ViewBag.layout = l;
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentID,PatientID,PayableAmount,PaymentDate,PaymentMethod,Status")] Payment payment,FormCollection fc)
        {
            //if (ModelState.IsValid)
            //{
            payment.PaymentMethod = fc["RbPM"];
            payment.Status = fc["RbStatus"];
            payment.PaymentDate.ToString("mm-dd-yyyy");
            db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("", "Payment",new { l=3});
            //}

            //ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", payment.PatientID);
            //return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id, string pm, string s,DateTime d, int? l)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            if (pm.Equals("Cash"))
                ViewBag.p = 1;
            else if (pm.Equals("CreditCard"))
                ViewBag.p = 2;
            else if (pm.Equals("DebitCard"))
                ViewBag.p = 3;
            else if (pm.Equals("UPI"))
                ViewBag.p = 4;

            if (s.Equals("Paid"))
                ViewBag.n = 1;
            else
                ViewBag.n = 0;

            ViewBag.date = d.ToShortDateString();
            ViewBag.layout = l;
            ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", payment.PatientID);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentID,PatientID,PayableAmount,PaymentDate,PaymentMethod,Status")] Payment payment,FormCollection fc)
        {
            //if (ModelState.IsValid)
            //{
                payment.PaymentMethod = fc["RbPM"];
                payment.Status = fc["RbStatus"];
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new { l=3});
            //}
            //ViewBag.PatientID = new SelectList(db.Patients, "PatientID", "FirstName", payment.PatientID);
            //return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id, int? l)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.layout = l;
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
            return RedirectToAction("Index",new { l=3});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult PatientListAcc(int? l)
        {
            //int id= (int)RouteData.Values["did"];
            ViewBag.layout = l;
            List<Patient> patient = db.Patients.ToList();
            var PatientList = from p in patient select new PatientReport { patient = p };
            return View(PatientList);
        }
    }
}

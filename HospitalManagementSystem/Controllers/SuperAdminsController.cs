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
    public class SuperAdminsController : Controller
    {
        private HMSDbContext db = new HMSDbContext();

        // GET: SuperAdmins
        /* public ActionResult Index()
         {
             return View(db.Admin.ToList());
         }

         // GET: SuperAdmins/Details/5
         public ActionResult Details(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             SuperAdmin superAdmin = db.Admin.Find(id);
             if (superAdmin == null)
             {
                 return HttpNotFound();
             }
             return View(superAdmin);
         }

         // GET: SuperAdmins/Create
         public ActionResult Create()
         {
             return View();
         }

         // POST: SuperAdmins/Create
         // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
         // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Create([Bind(Include = "SID,FirstName,MiddleName,LastName,Phone,Email,Password,Status")] SuperAdmin superAdmin)
         {
             if (ModelState.IsValid)
             {
                 db.Admin.Add(superAdmin);
                 db.SaveChanges();
                 return RedirectToAction("Index");
             }

             return View(superAdmin);
         }

         // GET: SuperAdmins/Delete/5
         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             SuperAdmin superAdmin = db.Admin.Find(id);
             if (superAdmin == null)
             {
                 return HttpNotFound();
             }
             return View(superAdmin);
         }

         // POST: SuperAdmins/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id)
         {
             SuperAdmin superAdmin = db.Admin.Find(id);
             db.Admin.Remove(superAdmin);
             db.SaveChanges();
             return RedirectToAction("Index");
         }*/

        // GET: SuperAdmins/Edit/5
        public ActionResult Edit()
        {
            SuperAdmin superAdmin = db.Admin.Find(1);
            if (superAdmin == null)
            {
                return HttpNotFound();
            }
            return View(superAdmin);
        }

        // POST: SuperAdmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SID,FirstName,MiddleName,LastName,Phone,Email,Password,Status")] SuperAdmin superAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DashSuper","Home");
            }
            return View(superAdmin);
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

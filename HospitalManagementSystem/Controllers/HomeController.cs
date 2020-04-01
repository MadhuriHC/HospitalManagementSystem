using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn(string s)
        {
            ViewBag.msg = s;
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Registration user)
        {
            //string c = fc["Category"];
            if ((IsValid(user.Email, user.Password,user.Category)) && (user.Category.Equals("SuperAdmin")))
            {
                //DefaultController d = new DefaultController();
                //d.User(user.Email);
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("DashSuper", "Home");
            }
            else if (IsValid(user.Email, user.Password, user.Category) && user.Category.Equals("Doctor"))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Dashdoc", "Doctors", new { id = 1 });
            }
            else if (IsValid(user.Email, user.Password, user.Category) && user.Category.Equals("Receptionist"))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Dashrecep", "Staffs", new { id = 2 });
            }
            else if (IsValid(user.Email, user.Password, user.Category) && user.Category.Equals("Accountant"))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Dashacc", "Staffs", new { id = 3 });
            }
            else
            {
                ModelState.AddModelError("", "Login Details are wrong.");
            }
            return View(user);
        }

        public ActionResult DashSuper()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Registration user)
        {
            
            if (ModelState.IsValid)
            {
                using (HMSDbContext db = new HMSDbContext())
                {
                    //user.Category = fc["Category"];
                    //var NewUser = db.Registrations.Create();
                    //NewUser.Email = user.Email;
                    //NewUser.Password = user.Password;
                    db.Registrations.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("LogIn", "", new { s = "Registered Succesfully" });
                }
            }
            return View(user);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Home");
        }

        private bool IsValid(string email, string password,string category)
        {
            bool IsValid = false;
            using (HMSDbContext db1 = new HMSDbContext())
            {
                var user = db1.Registrations.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    if (user.Password == password/*crypto.Compute(password,user.PasswordSalt)*/)
                    {
                        if(user.Category==category)
                        {
                            IsValid = true;
                        }
                        
                    }
                }
            }
            return IsValid;
        }
    }
}
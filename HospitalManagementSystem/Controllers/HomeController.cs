using HospitalManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DashSuper()
        {
            return View("DashSuper");
        }
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                using (var context = new HMSDbContext())
                {
                    context.GuestResponses.Add(guestResponse);
                    context.SaveChanges();
                }
                return View("Index", guestResponse);
            }
            else
            {
                return View();
            }
        }

    }
}
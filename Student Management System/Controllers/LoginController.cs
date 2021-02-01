using Student_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management_System.Controllers
{
    public class LoginController : Controller
    {
        lindaaEntities db = new lindaaEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objcheck)
        {
            if(ModelState.IsValid)
            {
                using (lindaaEntities db = new lindaaEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objcheck.username) && a.password.Equals(objcheck.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        Session["Role"] = obj.role.ToString();
                        return RedirectToAction("Index", "Home");
                    }

                    else
                    {
                        ModelState.AddModelError("", "The Username or Password is incorrect");
                    }
                }
            }
         
            return View(objcheck);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
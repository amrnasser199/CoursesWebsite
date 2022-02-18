using CoursesWebsite.Areas.Admin.Models;
using CoursesWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account//loging
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel LoginInfo)
        {
            var adminservice = new AdminService();
            var ISLogin = adminservice.Login(LoginInfo.Email, LoginInfo.Password);
            if (ISLogin)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                LoginInfo.Message = "Email OR Password Is Incorrect!";
                return View(LoginInfo);
            }
        }
      

    }
}
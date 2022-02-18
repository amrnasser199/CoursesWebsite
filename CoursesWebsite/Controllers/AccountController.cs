using CoursesWebsite.Data;
using CoursesWebsite.Models;
using CoursesWebsite.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        private readonly TraineeService traineeService;
        public AccountController()
        {
            var db = new CourseIdentityContext();
            var userStore = new UserStore<MyIdentityUser>(db);
            userManager = new UserManager<MyIdentityUser>(userStore);
            traineeService = new TraineeService();
        }
        // GET: Account
        //   public async Task<ActionResult> Login()
       // {
          // create user كدا انا ب 
            //فى الداتا بيز وبديله ايميل وباسورد وبخليه ادمن
            //var user = await userManager.CreateAsync(new MyIdentityUser
            //{
            //    Email = "Moh@gmail.com",
            //    UserName = "Moh@gmail.com"
            //}, "12345678");
            //ViewBag.User = user.Succeeded; 
            //return View();
            //
            //userManager.AddToRole("73f6df96-0d4b-46fb-b795-6bcce45983fb", "Admin");
            //var UserAccount = userManager.Find("Moh@gmail.com", "12345678");
            //ViewBag.User = UserAccount.Email;
            //return View ();
      //  }
    [AllowAnonymous]
        public ActionResult Login(string ReturnUrl="")

        {
            return View(new LoginViewModel
            {
                ReturnUrl=ReturnUrl
            });         
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel logindata)
        {
            if (ModelState.IsValid)
            {
                var ExistUser = await userManager.FindAsync(logindata.Email, logindata.Password);
                if (ExistUser != null)
                {
                    await SignIn(ExistUser);
                    if (!string.IsNullOrEmpty(logindata.ReturnUrl))
                    {
                        return Redirect(logindata.ReturnUrl);
                    }

                    var UserRoles = userManager.GetRoles(ExistUser.Id);
                    var Role = UserRoles.FirstOrDefault();
                    if (Role == "Admin")
                    {
                        return RedirectToAction("Index", "Default", new { area = "Admin" });
                    }

                    return RedirectToAction("Index", "Default");
                }

                logindata.Message = "Invalid Email OR Password";
             
            }
            return View(logindata);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel UserInfo)
        {
            if(ModelState.IsValid)
            {
                var identityUser = new MyIdentityUser
                {
                    Email=UserInfo.Email,
                    UserName=UserInfo.Email
                };
              var CreationResult=  await userManager.CreateAsync(identityUser, UserInfo.Password);
                if(CreationResult.Succeeded)
                {
                    var UserId = identityUser.Id;
                    // user كدا دخلت  
                    //وخليته ادمن 
                    //password:01158126652
                    //الخطوة ديه بتم مرة واحدة بس علشان هوا بيبقى ادمن واحد اللى متحكم او العدد اللى انت عايزه
                    //  userManager.AddToRole(identityUser.Id, "Admin");
                    //   return RedirectToAction("Index","Default",new { area="Admin"});
                   var UserRole= userManager.AddToRole(UserId, "Trainee");
                    if(UserRole.Succeeded)
                    {
                       var savingtrainee= traineeService.Create(new Trainee
                        {
                            Name=UserInfo.Name,
                            Email=UserInfo.Email,
                            Is_Active=true,
                            Creation_Date=DateTime.Now
                        });
                        if(savingtrainee==null)
                        {
                            UserInfo.Message = "An error Occurred While Creating Your Account";
                            return View(UserInfo);
                        }
                        return RedirectToAction("Index", "Default");
                    }
                    //password:123456
                    return RedirectToAction("Index", "Default");
                }
                var message = CreationResult.Errors.FirstOrDefault();
                UserInfo.Message = message;

                return View(UserInfo);
            }

            return View(UserInfo);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var OwinContext = Request.GetOwinContext();
            var AuthManager = OwinContext.Authentication;
            AuthManager.SignOut("ApplicationCookie");
            Session.Abandon();
            return RedirectToAction("Index","Default");
        }

        private async Task SignIn(MyIdentityUser myIdentityUser)
        {
            var Identity = await userManager.CreateIdentityAsync(myIdentityUser, DefaultAuthenticationTypes.ApplicationCookie);
            var OwinContext = Request.GetOwinContext();
            var AuthManager = OwinContext.Authentication;
            AuthManager.SignIn(Identity);
        }
    }
}
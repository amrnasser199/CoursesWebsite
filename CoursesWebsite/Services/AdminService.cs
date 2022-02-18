using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Services
{
    public interface IAdminService
    {
        bool Login(string Email, string Password);
        bool ChangePassword(string Email, string Password);
        bool ForgotPassword(string Email, string Password);
    }

    public class AdminService : IAdminService
    {
        public Courses_DBEntities3 Context { get; set; }
        public AdminService()
        {
            Context = new Courses_DBEntities3();
        }
        public bool Login(string Email, string Password)
        {
            return Context.Admins.Where(a => a.Email == Email && a.Password == Password).Any();
        }
        public bool ChangePassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

    
    }
}
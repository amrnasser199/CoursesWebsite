using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Data
{
    public class CourseIdentityContext:IdentityDbContext<MyIdentityUser>
    {
        public CourseIdentityContext():base("CoursesConnection")
        {
                
        }
    }
    public class MyIdentityUser:IdentityUser
    {

    }
}
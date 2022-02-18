using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(CoursesWebsite.App_Start.Startup))]

namespace CoursesWebsite.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            CookieAuthenticationOptions cookieAuthentication = new CookieAuthenticationOptions();
            cookieAuthentication.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            cookieAuthentication.LoginPath = new PathString("/Account/Login");
            app.UseCookieAuthentication(cookieAuthentication); 
        }
    }
}

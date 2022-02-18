using AutoMapper;
using CoursesWebsite.App_Start;
using CoursesWebsite.Models;
using CoursesWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Controllers
{
    public class CourseController : Controller
    {

        private readonly IMapper mapper;
        private readonly CourseService courseService;

        public CourseController()
        {

            courseService = new CourseService();

            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Course
        public ActionResult Index()
        {
            var Courses = courseService.ReadByALL();
            var mappedCourse = mapper.Map<List<CourseModel>>(Courses);
            return View(mappedCourse);
        }
        public ActionResult Info(int?id)
        {
            if(id==null||id==0)
            {
                return HttpNotFound("This Course Is Not Found");
            }
            var MyCourse = courseService.ReadBYID(id.Value);
            if(MyCourse==null)
            {
                return HttpNotFound("This Course Is Not Found");

            }
            var mappedcourse = mapper.Map<CourseModel>(MyCourse);
            return View(mappedcourse);
        }
        public ActionResult Subscribe(int id)
        {
            if(!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { ReturnUrl = $"/Course/Subscribe/{id}" });
            }
            return View();
        }
    }  
}
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
    public class DefaultController : Controller
    {
        private readonly IMapper mapper;
        private readonly CourseService courseService;
    
        public DefaultController()
        {

            courseService = new CourseService();
        
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Default
        public ActionResult Index()
        {
            var Courses = courseService.ReadByALL();
            var mappedCourse = mapper.Map<List<CourseModel>>(Courses);
            return View(mappedCourse);
        }
    }
}
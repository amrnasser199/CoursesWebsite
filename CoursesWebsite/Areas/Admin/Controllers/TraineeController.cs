using AutoMapper;
using CoursesWebsite.App_Start;
using CoursesWebsite.Models;
using CoursesWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class TraineeController : Controller
    {
        private readonly TraineeCoursesService traineeCoursesService;
        private readonly IMapper mapper;
        public TraineeController()
        {
            traineeCoursesService = new TraineeCoursesService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Trainee
        public ActionResult Index(int?courseid)
        {
           if(courseid==null)
            {
                return HttpNotFound();
            }
            var TraineeCoursesList = traineeCoursesService.GetTrainees(courseid.Value);
            var MappedTraineeCourses = mapper.Map<IEnumerable<TraineeCourseModel>>(TraineeCoursesList);
            return View(MappedTraineeCourses);
        }
    }
}
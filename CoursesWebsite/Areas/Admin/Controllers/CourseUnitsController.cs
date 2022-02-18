using AutoMapper;
using CoursesWebsite.App_Start;
using CoursesWebsite.Data;
using CoursesWebsite.Models;
using CoursesWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Areas.Admin.Controllers
{
    public class CourseUnitsController : Controller
    {
        private readonly IMapper mapper;
        private readonly CourseUnitService courseUnitService;

        public CourseUnitsController()
        {
            courseUnitService = new CourseUnitService();
            mapper = AutoMapperConfig.Mapper;

        }
        // GET: Admin/CourseUnits?CourseId
        public ActionResult Index(int? courseId)
        {
            if(courseId == null)
            {
                return HttpNotFound();
            }
            var unit= courseUnitService.ReadByALL(courseId.Value);
            var mappedUnits = mapper.Map<IEnumerable<CourseUnitModel>>(unit);
            ViewBag.CourseName = mappedUnits.FirstOrDefault()?.Name;
            ViewBag.CourseId = courseId;
            return View(mappedUnits);
        }

        // GET: Admin/CourseUnits/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/CourseUnits/Create
        public ActionResult Create()
        {
            return View();
        }
        // create /postديه طريقة اقدر اعملها فى 
        //ابعتهم ك parameters
        //public JsonResult Create(int CourseId,string UnitName)
        //{
        //    var unit = new Course_Units
        //    {
        //        Name=UnitName,
        //        Course_Id=CourseId
              
        //    };
        //    return Json();
        //}
        //واقدر اعملها بطريقة تانية زى انى ابعتله 
        //object بدل من
        //string name / int course id as parameter عملت

        // POST: Admin/CourseUnits/Create
        [HttpPost]
        public ActionResult Create(CourseUnitModel unitdata)
        {
            
            try
            {
                // TODO: Add insert logic here

                var unit = mapper.Map<Course_Units>(unitdata);
                unit.Course = null;
                var SavingUnit = courseUnitService.Create(unit);
                //if (SavingUnit > 0)
                //{
                //    return Json(new { saved = true });
                //}
                //else if (SavingUnit == -2)
                //{
                //    return Json(new { saved = false, message = "Exists" });

                //}
                //if (SavingUnit >= 1)
                //{
                //    return RedirectToAction("Index");
                //}
                //else if (SavingUnit == -2)
                //{
                //    ViewBag.Message = "An exists Trainer with this email";

                //}
                //else
                //{
                //    ViewBag.Message = "An error Occured";

                //}
                //return View(unitdata);
                if (SavingUnit == SavingStatus.Saved)
                {
                    return Json(new { saved = true });
                }
                else if (SavingUnit == SavingStatus.Exists)
                {
                    return Json(new { saved = false, message = "Exists" });

                }
                else
                {
                    return Json(new { saved = false });
                }
            }
            catch(Exception ex)
            {
                return Json(new { saved = false, message = ex.Message });
            }
        }

        // GET: Admin/CourseUnits/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/CourseUnits/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CourseUnits/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/CourseUnits/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

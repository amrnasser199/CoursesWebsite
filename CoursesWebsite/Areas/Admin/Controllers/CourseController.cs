using AutoMapper;
using CoursesWebsite.App_Start;
using CoursesWebsite.Data;
using CoursesWebsite.Models;
using CoursesWebsite.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Areas.Admin.Controllers
{
    [Authorize (Roles ="Admin")]
    public class CourseController : Controller
    {
        private readonly IMapper mapper;
        private readonly CourseService courseService;
        private readonly CategoryService categoryService;
        private readonly TrainerService trainerService;
        public CourseController()
        {

            courseService = new CourseService();
            categoryService = new CategoryService();
            trainerService = new TrainerService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Course
        public ActionResult Index(string Query= null, int? CategoryId = null ,int?TrainerId=null)
        {
            var CourseListModel = new CourseListModel();
            InitSelectList(ref CourseListModel);
            var courses = courseService.ReadByALL(Query,CategoryId,TrainerId);
            var mappedcourses = mapper.Map < IEnumerable< CourseModel >> (courses);
            CourseListModel.Courses = mappedcourses;
            return View(CourseListModel);
        }
        public ActionResult Create()
        {
            var CourseModel = new CourseModel();
            InitSelectList(ref CourseModel);
            return View(CourseModel);
        }
        [HttpPost]
        public ActionResult Create(CourseModel CourseData)
        {
            InitSelectList(ref CourseData);

            //if (CourseData.ImageFile==null||CourseData.ImageFile.ContentLength==0)
            //{
            //    return View(CourseData);
            //}
         
            try
            {
                if (ModelState.IsValid)
                {
                    CourseData.Image_ID = SaveImageFile(CourseData.ImageFile);

                    var mappedCourse = mapper.Map<Course>(CourseData);
                    mappedCourse.Category = null;
                    mappedCourse.Trainer = null;
                    int result = courseService.Create(mappedCourse);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Message = "An Error Occured";
                }
                return View(CourseData);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(CourseData);
            }
            
        }
        public ActionResult Edit(int? Id)
        {
            if(Id==null)
            {
                return HttpNotFound();
            }
            
            var currentCoursedata = courseService.ReadBYID(Id.Value);
            var mappedcourse = mapper.Map<CourseModel>(currentCoursedata);
            InitSelectList(ref mappedcourse);
            return View(mappedcourse);
        }
        [HttpPost]
        public ActionResult Edit(CourseModel CourseData)
        {
            InitSelectList(ref CourseData);

            try
            {
                if (ModelState.IsValid)
                {
                    CourseData.Image_ID=SaveImageFile(CourseData.ImageFile, CourseData.Image_ID);

                    var mappedCourse = mapper.Map<Course>(CourseData);
                    mappedCourse.Category = null;
                    mappedCourse.Trainer = null;

                    int result = courseService.Update(mappedCourse);
                     
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }
                    ViewBag.Message = "An Error Occured";
                }
                return View(CourseData);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(CourseData);
            }

        }
        private void InitSelectList(ref CourseModel courseModel)
        {
            var mappedCategory = GetCategories();
            courseModel.Categories = new SelectList(mappedCategory, "Id", "Name");

            var mappedTrainer = GetTrainers();
            courseModel.Trainers = new SelectList(mappedTrainer, "ID", "Name");
        }

        private void InitSelectList(ref CourseListModel  courseList)
        {
           var mappedCategory= GetCategories();
            courseList.Categories = new SelectList(mappedCategory, "Id", "Name");

            var mappedTrainer = GetTrainers();
            courseList.Trainers = new SelectList(mappedTrainer, "ID", "Name");
        }

        private IEnumerable<CategoryModel>GetCategories()
        {
            var Categories = categoryService.ReadAll();
            var mappedCategory = mapper.Map<IEnumerable<CategoryModel>>(Categories);
            return mappedCategory;
        }
        private IEnumerable<TrainerModel> GetTrainers()
        {
            var Trainers = trainerService.ReadALL();
            var mappedTrainer = mapper.Map<IEnumerable<TrainerModel>>(Trainers);
            return mappedTrainer;
        }

        private string SaveImageFile(HttpPostedFileBase ImageFile,string CurrentImageID="")
        {
            if (ImageFile != null)
            {
                var FileExtension = Path.GetExtension(ImageFile.FileName);
                var imageGuid = Guid.NewGuid().ToString();
                string Image_ID = imageGuid + FileExtension;

                //saving file or picture
                string FilePath = Server.MapPath($"~/Uploads/Courses/{Image_ID}");
                ImageFile.SaveAs(FilePath);

                //Delete Old File
                if (!string.IsNullOrEmpty(CurrentImageID))
                {
                    string OldFilePath = Server.MapPath($"~/Uploads/Courses/{CurrentImageID}");
                    System.IO.File.Delete(OldFilePath);
                }
                return Image_ID;

            }
            return CurrentImageID;
        }
    }
}
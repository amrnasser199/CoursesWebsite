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
    [Authorize(Roles = "Admin")]

    public class TrainerController : Controller
    {
        private readonly TrainerService trainerService;
        private readonly IMapper mapper;
        public TrainerController()
        {
            trainerService = new TrainerService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Trainer
        public ActionResult Index()
        {
            var TrainerList = trainerService.ReadALL();
            var MappedTrainer = mapper.Map<IEnumerable<TrainerModel>>(TrainerList);
            return View(MappedTrainer);
        }

        // GET: Admin/Trainer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Trainer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Trainer/Create
        [HttpPost]
        public ActionResult Create(TrainerModel trainerdata )
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var TrainerDto = mapper.Map<Trainer>(trainerdata);
                 int result= trainerService.Create(TrainerDto);
                    if(result>=1)
                    {
                        return RedirectToAction("Index");
                    }
                    else if(result==-2)
                    {
                        ViewBag.Message = "An exists Trainer with this email";
                       
                    }
                    else
                    {
                        ViewBag.Message = "An error Occured";
                        
                    }
                   
                }
                // TODO: Add insert logic here

                return View(trainerdata);
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(trainerdata);
            }
        }

        // GET: Admin/Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Trainer/Edit/5
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

        // GET: Admin/Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Trainer/Delete/5
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

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

    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;
        private readonly IMapper mapper;
        public CategoryController()
        {
            categoryService = new CategoryService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = categoryService.ReadAll();
            var categoryList= mapper.Map<List<CategoryModel>>(categories);
            //var categoryList = new List<CategoryModel>();
            //foreach(var item in categories)
            //{
            //    categoryList.Add(new CategoryModel
            //    {
            //        Id=item.ID,
            //        Name=item.Name,
            //        Parent_Name=item.Category2?.Name
            //    });
            //}
            return View(categoryList);
        }
        public ActionResult Create ()
        {
            var CategoryModel = new CategoryModel();
            InitilizeMainCategory(null,ref CategoryModel);
            return View(CategoryModel);
        }

        [HttpPost]
        public ActionResult Create(CategoryModel data)
        {
              var NewCategory= mapper.Map<Category>(data);
            NewCategory.Category2 = null;

            int CreationResult = categoryService.Create(NewCategory);
               //int CreationResult= categoryService.Create(new Data.Category
               // { 
               // Name=data.Name,
               // Parent_ID=data.Parent_ID
               // });
                if(CreationResult==-2)
                {
                InitilizeMainCategory(null ,ref data);

                ViewBag.Message = "Category Name IS Exists";
                    return View(data);
                }
                return RedirectToAction("Index");
            
        }
        public ActionResult Edit(int?id)
        { 
            //لازم نتاكد ان ال id 
            // لا يساوىnull
            // فى كل مرة بعمل edit
            //controller فى أى
            if (id == null || id == 0)
            {
                return RedirectToAction("Index","Home");
            }
            var CurrentCategory = categoryService.ReadBYID(id.Value);
            if(CurrentCategory==null)
            {
                return HttpNotFound($"This Category({id} Not Found!)");
            }
            var CategoryModel = new CategoryModel
            {
                Id=CurrentCategory.ID,
                Name=CurrentCategory.Name,
                Parent_ID=CurrentCategory.Parent_ID
            };
            InitilizeMainCategory(CurrentCategory.ID,ref CategoryModel);

            return View(CategoryModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel data)
        {
            
                var UpdatedCategory = new Data.Category { 
                ID=data.Id,
                Name=data.Name,
                Parent_ID=data.Parent_ID
                };
              
                var result= categoryService.Update(UpdatedCategory);
                if (result == -2)
                {
                    InitilizeMainCategory(data.Id,ref data);

                    ViewBag.Message = "Category Name IS Exists";
                    return View(data);
                }
                if (result>0)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = $"Category({data.Id})Updated Successfully";
                }
                else
                {
                    ViewBag.Message = $"An Error Occured!";
                }
            InitilizeMainCategory(data.Id, ref data);

            return View(data);
           
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                var currentCategory = categoryService.ReadBYID(id.Value);
                var CategoryModel = new CategoryModel
                {
                    Id = currentCategory.ID,
                    Name=currentCategory.Name,
                    //Parent_ID=currentCategory.Parent_ID,
                    Parent_Name=currentCategory.Category2?.Name
                };
                return View(CategoryModel);
            }
           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult ConfirmedDelete(int? id)
        {
            if(id!=null)
            {
                var deleted = categoryService.Delete(id.Value);
                if(deleted)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Delete", new { id = id });
            }
            return HttpNotFound();
        }

        private void InitilizeMainCategory(int? CategoryToExclude ,ref CategoryModel categoryModel)
        {
            var CategoryList = categoryService.ReadAll();
            if(CategoryToExclude!=null)
            {
                var CurrentCategory = CategoryList.Where(c => c.ID == CategoryToExclude).FirstOrDefault();
                CategoryList.Remove(CurrentCategory);
            }
            categoryModel.MainCategories = new SelectList(CategoryList, "ID", "Name");
            
        }

    }
}

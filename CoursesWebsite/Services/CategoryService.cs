using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Services
{
    public interface ICategoryService
    {
        List<Category> ReadAll();
        int Create(Category category);
        Category ReadBYID(int id);
        int Update(Category UpdatedCategory);
        bool Delete(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly Courses_DBEntities3 db;
        public CategoryService()
        {
            db = new Courses_DBEntities3();
        }
        public List<Category> ReadAll()
        {
            return db.Categories.ToList();
        }

        public Category ReadBYID(int id)
        {
            return db.Categories.Find(id);
        }
        public int Create(Category NewCategory)
        {
            var CategoryName = NewCategory.Name.ToLower();
            var CAtegoryNameExist = db.Categories.Where(c => c.Name.ToLower() == CategoryName).Any();
            if (CAtegoryNameExist)
            {
                return -2;
            }
            db.Categories.Add(NewCategory);
            return db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var DelCAt = ReadBYID(id);
            if(DelCAt!=null)
            {
               db.Categories.Remove(DelCAt);
               return db.SaveChanges() > 0 ?true :false;
            }
            return false;
        }

      

        public int Update(Category UpdatedCategory)
        {
            var CategoryName = UpdatedCategory.Name.ToLower();
            var CAtegoryList = db.Categories.Where(c => c.Name.ToLower() != CategoryName);
            if (CAtegoryList.Where (c => c.Name.ToLower() == CategoryName).Any())
            {
                return -2;
            }
            db.Categories.Attach(UpdatedCategory);
            db.Entry(UpdatedCategory).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
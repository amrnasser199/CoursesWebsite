using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace CoursesWebsite.Services
{
    public interface ICourseUnitService
    {
        SavingStatus Create(Course_Units Unit);
        IEnumerable<Course_Units> ReadByALL(int courseId);
        Course_Units ReadBYID(int id);
        int Update(Course_Units UpdatedUnitcourse);
        Course_Units GetExistCourseUnit(int courseId, string name);
         int Crete(Course_Units units);

    }
    public class CourseUnitService : ICourseUnitService
    {
        private readonly Courses_DBEntities3 db;
        public CourseUnitService()
        {
            db = new Courses_DBEntities3();

        }
        //ديه طريقة جديدة 
        //بستخدم ال enum
        //علشان مايبقاش عندى مجال للخطا فى الكود بدل ما ابعتله ارقام وابعتله -1 ويبقى فيه مشكلة فى ال 
        //saving
        //المفروض ابعتله غى الكود -2 مش -1 علشان مايحصلش 
        //exception
        //ملحوظة: ممكن استخدم الطريقة القديمة طريقة الارقام بدل 
        // enums .....عادى جدا
        public SavingStatus Create(Course_Units unit)
        {
            var existsUnit =GetExistCourseUnit(unit.Course_Id, unit.Name);
            if (existsUnit != null)
            {
                return SavingStatus.Exists;
            }

            db.Course_Units.Add(unit);
            //try
            //{
            //    var result = db.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
            //    {
            //        // Get entry

            //        DbEntityEntry entry = item.Entry;
            //        string entityTypeName = entry.Entity.GetType().Name;

            //        // Display or log error messages

            //        foreach (DbValidationError subItem in item.ValidationErrors)
            //        {
            //            string message = string.Format("Error '{0}' occurred in {1} at {2}",
            //                     subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
            //            Console.WriteLine(message);
            //        }
            //        switch (entry.State)
            //        {
            //            case EntityState.Added:
            //                entry.State = EntityState.Detached;
            //                break;
            //            case EntityState.Modified:
            //                entry.CurrentValues.SetValues(entry.OriginalValues);
            //                entry.State = EntityState.Unchanged;
            //                break;
            //            case EntityState.Deleted:
            //                entry.State = EntityState.Unchanged;
            //                break;
            //        }
            //    }
            //}
            int result = db.SaveChanges();

            if (result > 0)
               return SavingStatus.Saved;

            return SavingStatus.Error;
        }
  
        public int Crete(Course_Units units)
        {
            var existsUnit = GetExistCourseUnit(units.Course_Id, units.Name);
           
           
            if(existsUnit!= null)
            {
                return -2;

            }


            db.Course_Units.Add(units);
            //try
            //{
            //    var result = db.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
            //    {
            //        // Get entry

            //        DbEntityEntry entry = item.Entry;
            //        string entityTypeName = entry.Entity.GetType().Name;

            //        // Display or log error messages

            //        foreach (DbValidationError subItem in item.ValidationErrors)
            //        {
            //            string message = string.Format("Error '{0}' occurred in {1} at {2}",
            //                     subItem.ErrorMessage, entityTypeName, subItem.PropertyName);
            //            Console.WriteLine(message);
            //        }
            //        switch (entry.State)
            //        {
            //            case EntityState.Added:
            //                entry.State = EntityState.Detached;
            //                break;
            //            case EntityState.Modified:
            //                entry.CurrentValues.SetValues(entry.OriginalValues);
            //                entry.State = EntityState.Unchanged;
            //                break;
            //            case EntityState.Deleted:
            //                entry.State = EntityState.Unchanged;
            //                break;
            //        }
            //    }
            //}
            return db.SaveChanges();
        }
        public IEnumerable<Course_Units> ReadByALL(int courseId)
        {
            return db.Course_Units.Where(d =>d.Course_Id == courseId);
        }

        public Course_Units ReadBYID(int id)
        {
            return db.Course_Units.Find(id);
        }

        public Course_Units GetExistCourseUnit(int courseId, string name)
        {
            return db.Course_Units.FirstOrDefault(u => u.Course_Id == courseId && u.Name == name);
        }

        public int Update(Course_Units UpdatedUnitcourse)
        {
            throw new NotImplementedException();
        }
    }
}
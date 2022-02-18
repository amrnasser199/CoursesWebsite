using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Services
{
    public interface ICourseService
    {
        int Create(Course course);
        IEnumerable<Course> ReadByALL(string Query, int? CategorId, int? TrainerId = null);
        Course ReadBYID(int id);
        int Update(Course Updatedcourse);
    }
    public class CourseService : ICourseService
    {
        private readonly Courses_DBEntities3 db;
        public CourseService()
        {
            db = new Courses_DBEntities3();
        }
        public int Create(Course course)
        {
            course.Creation_Date = DateTime.Now;
            db.Courses.Add(course);
            return db.SaveChanges();
        }

        public IEnumerable<Course> ReadByALL(string Query=null,int?CategorId=null,int?TrainerId=null)
        {
            return db.Courses.Where(d =>
           ( TrainerId == null || d.Trainer_ID ==TrainerId)
                &&(CategorId==null||d.Category_ID==CategorId)
                &&(Query==null||d.Name.Contains(Query)));
        }

        public Course ReadBYID(int id)
        {
            return db.Courses.Find(id);
        }

        public int Update(Course Updatedcourse)
        {
            db.Courses.Attach(Updatedcourse);
            db.Entry(Updatedcourse).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        
    }
}
using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Services
{
    public interface ITraineeCoursesService
    {
        IEnumerable<Trainee_Courses> GetTrainees(int? CourseID);
    }
    public class TraineeCoursesService : ITraineeCoursesService
    {
        private readonly Courses_DBEntities3 db;
        public TraineeCoursesService()
        {
            db = new Courses_DBEntities3();
                
        }
        public IEnumerable<Trainee_Courses> GetTrainees(int? CourseID=null)
        {
            return db.Trainee_Courses.Where(c =>
                      CourseID==null||c.Course_ID == CourseID) ;
        }
    }
}
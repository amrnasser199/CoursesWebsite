using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Services
{
    public interface ITraineeService
    {
        Trainee Create(Trainee trainee);
    }
    public class TraineeService : ITraineeService
    {
        private readonly Courses_DBEntities3 db;
        public TraineeService()
        {
            db = new Courses_DBEntities3();

        }
        public Trainee Create(Trainee trainee)
        {
            db.Trainees.Add(trainee);
            var result = db.SaveChanges();
            if (result > 0)
            {
                return trainee;
            }
            return null;
        }
    }
}
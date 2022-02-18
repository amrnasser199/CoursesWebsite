using CoursesWebsite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Services
{
    public interface ITrainerService
    {
        int Create(Trainer trainer);
        Trainer FinddBYEmail(string email);
        IEnumerable<Trainer> ReadALL();
        int ReadBYID(int Id);


    }
    public class TrainerService : ITrainerService
    {
        private readonly Courses_DBEntities3 db;
        public TrainerService()
        {
            db = new Courses_DBEntities3();
        }
        public int Create(Trainer trainer)
        {
            var existTrainer = FinddBYEmail(trainer.Email);
            if(existTrainer!=null)
            {
                return -2;
            }
            trainer.Creation_Date = DateTime.Now;
            db.Trainers.Add(trainer);
            return db.SaveChanges();
        }

        public Trainer FinddBYEmail(string email)
        {
            return db.Trainers.Where(a => a.Email == email).FirstOrDefault();

        }

        public IEnumerable<Trainer> ReadALL()
        {
            return db.Trainers.ToList();
        }

        public int ReadBYID(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
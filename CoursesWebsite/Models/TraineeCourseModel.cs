using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Models
{
    public class TraineeCourseModel
    {
        public int Course_ID { get; set; }
        public System.DateTime Registeration_Date { get; set; }
        public TraineeModel Trainee { get; set; }
    }
    public class TraineeModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }


}
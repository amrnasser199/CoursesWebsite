using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Models
{
    public class CourseModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public System.DateTime Creation_Date { get; set; }
        public string Desciption { get; set; }
        [Required]
        [Display(Name ="Category")]
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        [Display(Name = "Trainer")]
        public Nullable<int> Trainer_ID { get; set; }
        public string Trainer_Name { get; set; }

        private string _image_ID;
        public string Image_ID {
            set
            {
                _image_ID = string.IsNullOrEmpty(value) ? "unnamed.png" : value;
              
               
            }


            get
            {
                return _image_ID;
            }
            }
        public HttpPostedFileBase ImageFile { get; set; }

        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }

    }
    public class CourseListModel
    {
        public IEnumerable<CourseModel> Courses { get; set; }
        public string Query  { get; set; }
        public int TrainerId { get; set; }
        public int CategoryId { get; set; }
        public SelectList Trainers { get; set; }
        public SelectList Categories { get; set; }
    }
    public class CourseUnitModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course_Id { get; set; }
        public string CourseName { get; set; }
    }
}
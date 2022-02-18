using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoursesWebsite.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You Should Enter Category Name")]
        [StringLength(200,MinimumLength =4,ErrorMessage ="Category Name Should Be Between 5 and 200")]
        public string Name { get; set; }
        public int? Parent_ID { get; set; }
        public string Parent_Name { get; set; }
        public SelectList MainCategories { get; set; }
    }
}
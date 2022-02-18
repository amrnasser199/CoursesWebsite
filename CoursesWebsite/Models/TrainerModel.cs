using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Models
{
    public class TrainerModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="please enter your Name")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter valid format")]
        [EmailAddress ]
        public string Email { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string Description { get; set; }
        [Required(ErrorMessage = "please enter correct url ")]
        [Url]
        public string Website { get; set; }
        public System.DateTime Creation_Date { get; set; }
    }
}
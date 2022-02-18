using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Models
{
    public class RegisterViewModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Password doesnot Match")]
        public string ConfirmPassword { get; set; }
        public string Message { get; set; }
    }
}
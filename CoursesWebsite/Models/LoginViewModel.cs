using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoursesWebsite.Models
{
    public class LoginViewModel

    { 
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public string Message { get; set; }
    }
}
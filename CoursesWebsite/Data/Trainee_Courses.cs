//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoursesWebsite.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trainee_Courses
    {
        public int Trainee_ID { get; set; }
        public int Course_ID { get; set; }
        public System.DateTime Registeration_Date { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Trainee Trainee { get; set; }
    }
}

using AutoMapper;
using CoursesWebsite.Data;
using CoursesWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoursesWebsite.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<Category, CategoryModel>()
                .ForMember(dst => dst.Id, src => src.MapFrom(e => e.ID))
                .ForMember(dst => dst.Parent_ID, src => src.MapFrom(e => e.Category2.Parent_ID))
                .ForMember(dst => dst.Parent_Name, src => src.MapFrom(e => e.Category2.Name))
                .ReverseMap();

                cfg.CreateMap<Trainer, TrainerModel>().ReverseMap();

                cfg.CreateMap<Course, CourseModel>()
                .ForMember(dst => dst.ID, src => src.MapFrom(a => a.ID))
                .ForMember(dst => dst.Trainer_Name, src => src.MapFrom(a => a.Trainer.Name))
                .ForMember(dst => dst.Category_Name, src => src.MapFrom(a => a.Category.Name))
                .ReverseMap();

                cfg.CreateMap<Trainee, TraineeModel>().ReverseMap();

                cfg.CreateMap<Trainee_Courses, TraineeCourseModel>()
                .ForMember(dst => dst.Course_ID, src => src.MapFrom(c => c.Course_ID))
                .ForMember(dst => dst.Registeration_Date, src => src.MapFrom(c => c.Registeration_Date))
                .ForMember(dst => dst.Trainee, src => src.MapFrom(c => c.Trainee))
                .ReverseMap();


                cfg.CreateMap<Course_Units, CourseUnitModel>()
                    .ForMember(dst => dst.CourseName, src => src.MapFrom(c => c.Name))
                    .ForMember(dst => dst.Name, src => src.MapFrom(c => c.Name))
                 .ReverseMap();
            });
            Mapper = config.CreateMapper();
        }
    }
}
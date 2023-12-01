
using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System.Runtime.InteropServices;

namespace Application
{
    public class StudentMapper :Profile
    {
        public StudentMapper() 
        {   
            CreateMap<Student, StudentDTO>().ReverseMap();//GET
            CreateMap<Course,CourseDTO>().ReverseMap();

            CreateMap<Student,AddStudentDTO>().ReverseMap();//POST

    
        }
    }
}

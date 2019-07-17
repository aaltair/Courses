using AutoMapper;
using Courses.Dtos.Author;
using Courses.Dtos.Course;
using Courses.Entities;

namespace Courses.Services.Mapper
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
       {
           CreateMap<Author, AuthorDto>().ReverseMap();
           CreateMap<Author, CreateAuthorDto>().ReverseMap();
           CreateMap<Author, AuthorCourseDto>().ReverseMap();

           CreateMap<Course, CourseDto>().ReverseMap();
           CreateMap<Course, CreateCourseDto>().ReverseMap();
           CreateMap<Course, CourseAuthorDto>().ReverseMap();
        }
    }
}
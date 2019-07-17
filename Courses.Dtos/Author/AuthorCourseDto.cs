using System.Collections.Generic;
using Courses.Dtos.Course;

namespace Courses.Dtos.Author
{
    public class AuthorCourseDto
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public ICollection<CourseDto> Courses { set; get; }
    }
}
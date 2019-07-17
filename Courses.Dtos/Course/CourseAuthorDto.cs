using Courses.Dtos.Author;

namespace Courses.Dtos.Course
{
    public class CourseAuthorDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCategory { get; set; }
        public int AuthorId { get; set; }
        public  AuthorDto Author { set; get; }
    }
}
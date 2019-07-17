using Courses.Dtos.Author;
using Courses.Dtos.Course;
using FluentValidation;

namespace Courses.Services.Validators
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
      public CreateCourseValidator()
      {
          RuleFor(w => w.CourseName).NotNull().NotEmpty();
          RuleFor(w => w.CourseCategory).NotNull().NotEmpty();
          RuleFor(w => w.AuthorId).NotNull().NotEmpty();
      }
    }
}
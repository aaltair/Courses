using Courses.Dtos.Author;
using Courses.Dtos.Course;
using FluentValidation;

namespace Courses.Services.Validators
{
    public class UpdateCourseValidator : AbstractValidator<CourseDto>
    {
      public UpdateCourseValidator()
      {
          RuleFor(w => w.CourseId).NotNull().NotEmpty();
          RuleFor(w => w.CourseName).NotNull().NotEmpty();
          RuleFor(w => w.CourseCategory).NotNull().NotEmpty();
          RuleFor(w => w.AuthorId).NotNull().NotEmpty();
      }
    }
}
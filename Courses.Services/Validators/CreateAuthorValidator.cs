using Courses.Dtos.Author;
using FluentValidation;

namespace Courses.Services.Validators
{
    public class CreateAuthorValidator :AbstractValidator<CreateAuthorDto>
    {
      public  CreateAuthorValidator()
      {
          RuleFor(w => w.AuthorName).NotNull().NotEmpty();
      }
    }
}
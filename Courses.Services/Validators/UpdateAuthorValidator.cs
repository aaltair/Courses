using Courses.Dtos.Author;
using FluentValidation;

namespace Courses.Services.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<AuthorDto>
    {
      public UpdateAuthorValidator()
      {
          RuleFor(w => w.AuthorId).NotNull().NotEmpty();
          RuleFor(w => w.AuthorName).NotNull().NotEmpty();
      }
    }
}
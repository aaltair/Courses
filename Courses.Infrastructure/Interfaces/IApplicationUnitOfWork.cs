using Courses.Infrastructure.Contexts;
using Courses.Infrastructure.Repositories;

namespace Courses.Infrastructure.Interfaces
{
    public interface IApplicationUnitOfWork : IUnitOfWork<ApplicationDbContext>
    {
        AuthorRepository AuthorRepository { get; }
        CourseRepository CourseRepository { get; }
        UserRepository UserRepository { get; }
    }
}
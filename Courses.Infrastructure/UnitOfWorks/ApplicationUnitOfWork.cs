using Courses.Infrastructure.Contexts;
using Courses.Infrastructure.Interfaces;
using Courses.Infrastructure.Repositories;

namespace Courses.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork<ApplicationDbContext>, IApplicationUnitOfWork
    {
        #region filed
        private AuthorRepository _authorRepository;
        private CourseRepository _courseRepository;
        private UserRepository _userRepository;


        #endregion

        public ApplicationUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #region initlitation
        public AuthorRepository AuthorRepository => _authorRepository ?? (_authorRepository = new AuthorRepository(_context));
        public CourseRepository CourseRepository => _courseRepository ?? (_courseRepository = new CourseRepository(_context));
        public UserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_context));

        #endregion
    }

}
using Courses.Entities;
using Courses.Infrastructure.Abstracts;
using Courses.Infrastructure.Contexts;

namespace Courses.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
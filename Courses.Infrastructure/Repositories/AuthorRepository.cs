using Courses.Entities;
using Courses.Infrastructure.Abstracts;
using Courses.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public class AuthorRepository :BaseRepository<Author>
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
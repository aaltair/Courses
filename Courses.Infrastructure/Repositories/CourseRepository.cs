using Courses.Entities;
using Courses.Infrastructure.Abstracts;
using Courses.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Repositories
{
    public class CourseRepository :BaseRepository<Course>
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
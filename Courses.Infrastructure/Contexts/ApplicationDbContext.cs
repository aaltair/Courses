using System;
using Courses.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Courses.Infrastructure.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            FluentApi(builder);
            SeedData(builder);
            GlobalFilters(builder);

        }

        private void GlobalFilters(ModelBuilder builder)
        {
            builder.Entity<Author>().HasQueryFilter(w => !w.IsDelete );
            builder.Entity<Course>().HasQueryFilter(w => !w.IsDelete );
            builder.Entity<ApplicationUser>().HasQueryFilter(w => !w.IsDelete );
        }

        private void SeedData(ModelBuilder builder)
        {
            builder.Entity<Author>().HasData(new Author[]
            {
                new Author {AuthorId = 1, AuthorName = "Alaa Altair", CreatedOn = DateTime.Now},
                new Author {AuthorId = 2, AuthorName = "Ali Altair", CreatedOn = DateTime.Now},
                new Author {AuthorId = 3, AuthorName = "Ahmad Altair", CreatedOn = DateTime.Now},
            });

            builder.Entity<Course>().HasData(new Course[]
                {
                    new Course
                    {
                        CourseId = 1, CourseCategory = "FullStack", AuthorId = 1, CourseName = ".Net Core With React",
                        CreatedOn = DateTime.Now
                    },
                    new Course
                    {
                        CourseId = 2, CourseCategory = "FrontEnd", AuthorId = 2, CourseName = "React With Redux",
                        CreatedOn = DateTime.Now
                    },
                    new Course
                    {
                        CourseId = 3, CourseCategory = "BackEnd", AuthorId = 3, CourseName = ".Net Core WebApi",
                        CreatedOn = DateTime.Now
                    },
                }
            );

            var hash = new PasswordHasher<ApplicationUser>();
            var ADMIN_ID = Guid.NewGuid().ToString();
            var ROLE_ID = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(new IdentityRole
                {Id = ROLE_ID, Name = "SuperAdmin", NormalizedName = "SuperAdmin".ToUpper()});

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "aaltair.developer@gmail.com",
                NormalizedEmail = "aaltair.developer@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PhoneNumber = "+962788260020",
                PhoneNumberConfirmed = true,
                FirstName = "Alaa",
                SecondName = "Abbas",
                LastName = "Altair",
                BirthDate = new DateTime(1993, 1, 27),
                Address = "Amman",
                City = "Amman",
                PasswordHash = hash.HashPassword(null, "P@ssw0rd"),
                SecurityStamp = String.Empty,
                CreatedOn = DateTime.Now
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        
    }

        private void FluentApi(ModelBuilder builder)
        {

        }




    }
}
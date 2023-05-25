using Microsoft.EntityFrameworkCore;
using University.Domain.Common;
using University.Domain.Course;
using University.Domain.Entities;

namespace University.Persistence
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<SecuredUser> SecuredUsers { get; set; }
        public DbSet<EnrolledCourse> EnrolledCourses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "admin";
                        break;
                    case EntityState.Deleted:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "admin";
                        break;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

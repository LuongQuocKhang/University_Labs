using University.Domain.Entities;
using University.Persistence;

namespace University.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        protected readonly UniversityContext _dbContext;

        public CourseRepository(UniversityContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task EnrollCourseAsync(string userName, int courseId)
        {
            // check course existing
            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == courseId);
            if(course == null)
            {
                throw new ArgumentNullException("Course not existing!");
            }

            var enrolledCourse = new EnrolledCourse()
            {
                UserName = userName,
                CourseId = courseId
            };

            await _dbContext.EnrolledCourses.AddAsync(enrolledCourse).ConfigureAwait(false);
        }

        public Task UnEnrollCourseAsync(string userName, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}

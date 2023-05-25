using Dapper;
using University.Domain.Common;
using University.Domain.Course;
using University.Infrastructure.IServices;
using University.Persistence;

namespace University.Infrastructure.Implmeent
{
    public class CourseService : ICourseService
    {
        private readonly UniversityContextDapper _context;
        public CourseService(UniversityContextDapper context)
        {
            _context = context;
        }
        public Task EnrollCourseAsync(int userId, int courseId)
        {
            throw new NotImplementedException();
        }

        public Task EnrollCourseAsync(string userName, int courseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetAllAvaiableCoursesAsync()
        {
            string query = CourseQuery.GetAllAvailableCourse;

            using (var connection = _context.CreateConnection())
            {
                var courses = await connection.QueryAsync<Course>(query);
                return courses;
            }
        }

        public async Task<IEnumerable<Course>> GetAllCoursesWithEnrolledStudentAsync()
        {
            string query = CourseQuery.GetEnrolledCourse;

            using (var connection = _context.CreateConnection())
            {
                var courses = await connection.QueryAsync<Course>(query);
                return courses;
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesByNameAsync(string courseName)
        {
            string query = CourseQuery.GetCourseByName;
            query = query.Replace("@CourseName", courseName);

            using (var connection = _context.CreateConnection())
            {
                var courses = await connection.QueryAsync<Course>(query);
                return courses;
            }
        }

        public Task<IEnumerable<Course>> GetEnrolledCourseAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

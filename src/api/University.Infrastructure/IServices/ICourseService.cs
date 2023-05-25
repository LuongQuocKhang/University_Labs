using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Course;

namespace University.Infrastructure.IServices
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAvaiableCoursesAsync();
        Task<IEnumerable<Course>> GetEnrolledCourseAsync(string userName);
        Task<IEnumerable<Course>> GetCoursesByNameAsync(string courseName);
        Task<IEnumerable<Course>> GetAllCoursesWithEnrolledStudentAsync();
    }
}

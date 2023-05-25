using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Infrastructure.Repositories
{
    public interface ICourseRepository
    {
        Task EnrollCourseAsync(string userName, int courseId);
        Task UnEnrollCourseAsync(string userName, int courseId);
    }
}

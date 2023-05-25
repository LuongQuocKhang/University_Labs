using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Features.Course.Queries.GetAllEnrolledCourse
{
    public class GetAllEnrolledCourseQuery : IRequest<IEnumerable<Domain.Course.Course>>
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}

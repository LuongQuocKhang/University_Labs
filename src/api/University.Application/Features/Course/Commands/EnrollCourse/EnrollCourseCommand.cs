using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Features.Course.Commands.EnrollCourse
{
    public class EnrollCourseCommand : IRequest<bool>
    {
        public int CourseId { get; set; }
        public string UserName { get; set; }
    }
}

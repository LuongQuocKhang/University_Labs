using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Features.Course.Queries.GetCoursesByName
{
    public class GetCoursesByNameQuery : IRequest<IEnumerable<Domain.Course.Course>>
    {
        public string CourseName { get; set; }
    }
}

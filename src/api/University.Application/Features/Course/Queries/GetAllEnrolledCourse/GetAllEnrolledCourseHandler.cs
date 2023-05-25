using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;
using University.Infrastructure.IServices;

namespace University.Application.Features.Course.Queries.GetAllEnrolledCourse
{

    public class GetAllEnrolledCourseHandler : IRequestHandler<GetAllEnrolledCourseQuery, IEnumerable<Domain.Course.Course>>
    {
        private readonly ICourseService _courceService;

        public GetAllEnrolledCourseHandler(ICourseService courceService)
        {
            _courceService = courceService;
        }
        public async Task<IEnumerable<Domain.Course.Course>> Handle(GetAllEnrolledCourseQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courceService.GetEnrolledCourseAsync(request.Email);
            return courses;
        }
    }
}

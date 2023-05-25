using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Domain.Course;
using University.Infrastructure.IServices;

namespace University.Application.Features.Course.Queries.GetAllAvailableCourse
{
    public class GetAllAvailableCourseHandler : IRequestHandler<GetAllAvailableCourseQuery, IEnumerable<Domain.Course.Course>>
    {
        private readonly ICourseService _courceService;

        public GetAllAvailableCourseHandler(ICourseService courceService)
        {
            _courceService = courceService;
        }

        public async Task<IEnumerable<Domain.Course.Course>> Handle(GetAllAvailableCourseQuery request, CancellationToken cancellationToken)
        {
            var course = await _courceService.GetAllAvaiableCoursesAsync();
            return course;
        }
    }
}

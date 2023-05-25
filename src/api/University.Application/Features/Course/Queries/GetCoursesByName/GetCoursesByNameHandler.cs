using MediatR;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;
using University.Infrastructure.IServices;

namespace University.Application.Features.Course.Queries.GetCoursesByName
{
    public class GetCoursesByNameHandler : IRequestHandler<GetCoursesByNameQuery, IEnumerable<Domain.Course.Course>>
    {
        private readonly ICourseService _courceService;

        public GetCoursesByNameHandler(ICourseService courceService)
        {
            _courceService = courceService;
        }
        public async Task<IEnumerable<Domain.Course.Course>> Handle(GetCoursesByNameQuery request, CancellationToken cancellationToken)
        {
            var course = await _courceService.GetCoursesByNameAsync(request.CourseName);
            return course;
        }
    }
}

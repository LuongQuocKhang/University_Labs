using MediatR;

namespace University.Application.Features.Course.Queries.GetAllAvailableCourse
{
    public class GetAllAvailableCourseQuery : IRequest<IEnumerable<Domain.Course.Course>>
    {
    }
}

using MediatR;
using University.Infrastructure.IServices;
using University.Infrastructure.Repositories;

namespace University.Application.Features.Course.Commands.EnrollCourse
{
    public class EnrollCourseCommandHandler : IRequestHandler<EnrollCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public EnrollCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(EnrollCourseCommand request, CancellationToken cancellationToken)
        {
            await _courseRepository.EnrollCourseAsync(request.UserName, request.CourseId);
            return true;
        }
    }
}

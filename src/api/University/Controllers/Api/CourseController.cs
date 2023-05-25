using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

using University.Application.Features.Course.Commands.EnrollCourse;
using University.Application.Features.Course.Commands.UnEnrollCourse;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;
using University.Application.Features.Course.Queries.GetAllEnrolledCourse;
using University.Application.Features.Course.Queries.GetCoursesByName;
using University.Domain.Course;

namespace University.Controllers.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/course")]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet(Name = "GetAllAvailableCourses")]
        [ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllAvailableCourses()
        {
            var query = new GetAllAvailableCourseQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet]
        [Route("[Action]")]
        [ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllEnrolledCourses()
        {
            var query = new GetAllEnrolledCourseQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet]
        [Route("[Action]/{userName}")]
        [ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllEnrolledCoursesByUser(string userName)
        {
            var query = new GetAllEnrolledCourseQuery();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpGet]
        [Route("[Action]/{courseName=}")]
        [ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByName(string courseName = "")
        {
            var query = new GetCoursesByNameQuery()
            {
                CourseName = courseName
            };

            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPut]
        [Route("[Action]")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<Course>>> EnrollCourse()
        {
            var query = new EnrollCourseCommand();
           await _mediator.Send(query);
            return Ok();
        }

        [HttpPut]
        [Route("[Action]")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<IEnumerable<Course>>> UnEnrollCourse()
        {
            var query = new UnEnrollCourseCommand();
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }
    }
}

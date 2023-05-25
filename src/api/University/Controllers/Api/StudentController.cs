using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;
using University.Domain.Course;
using University.Domain.Entities;

namespace University.Controllers.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/student")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //[HttpGet(Name = "GetAllStudents")]
        //[ProducesResponseType(typeof(IEnumerable<Student>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        //{
        //    var query = new GetAllAvailableCourseQuery();
        //    var orders = await _mediator.Send(query);
        //    return Ok(orders);
        //}
    }
}

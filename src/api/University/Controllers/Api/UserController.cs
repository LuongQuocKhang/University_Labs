using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using University.Application.Features.Course.Queries.GetAllAvailableCourse;
using University.Domain.Course;

namespace University.Controllers.Api
{

    [ApiController]
    [Route("api/v{version:apiVersion}/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //[HttpGet(Name = "GetAllUsers")]
        //[ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult<IEnumerable<Course>>> GetAllUsers()
        //{
        //    var query = new GetAllAvailableCourseQuery();
        //    var orders = await _mediator.Send(query);
        //    return Ok(orders);
        //}

    }
}

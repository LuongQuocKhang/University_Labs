using Microsoft.AspNetCore.Mvc;
using Erp.Framework.Modules.Authentication;
using Erp.Framework.Modules.Dna;
using Erp.Framework.Modules.Guardian;

namespace University.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/app-users")]
    public class AppUsersController : ControllerBase
    {
        private readonly IApplicationUser _applicationUser;
        private readonly IDnaAppUser _dnaAppUser;
        private readonly IGuardianAppUser _guardianAppUser;

        public AppUsersController(IApplicationUser applicationUser, IDnaAppUser dnaAppUser, IGuardianAppUser guardianAppUser)
        {
            _applicationUser = applicationUser;
            _dnaAppUser = dnaAppUser;
            _guardianAppUser = guardianAppUser;
        }

        [HttpGet(Name = nameof(Me))]
        [ProducesResponseType(typeof(IApplicationUser), StatusCodes.Status200OK)]
        public IActionResult Me()
        {
            return new JsonResult(_applicationUser);
        }

        [HttpGet("Dna", Name = nameof(Dna))]
        [ProducesResponseType(typeof(IDnaAppUser), StatusCodes.Status200OK)]
        public IActionResult Dna()
        {
            return new JsonResult(_dnaAppUser);
        }

        [HttpGet("Guardian", Name = nameof(Guardian))]
        [ProducesResponseType(typeof(IGuardianAppUser), StatusCodes.Status200OK)]
        public IActionResult Guardian()
        {
            return new JsonResult(_guardianAppUser);
        }
    }
}
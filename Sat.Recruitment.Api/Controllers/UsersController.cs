using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.ErrorHandling;
using Sat.Recruitment.Core.DTOs;
using Sat.Recruitment.Recruitment.Core.DTOs;
using Sat.Recruitment.Service.Interfaces;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    /// <summary>
    /// Users
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// User constructor
        /// </summary>
        /// <param name="userService"></param>
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create user.
        /// </summary>
        /// <remarks>
        /// Notes: notes.
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <response code="201">Success: Returns the newly created item.</response>
        /// <response code="400">Bad Request: the input values are invalid.</response>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(UserCreateRequestDTO user)
        {
            var userResp = await _userService.CreateUserAsync(user);

            return Created(nameof(UserCreateResponseDTO), userResp);
        }
    }

}

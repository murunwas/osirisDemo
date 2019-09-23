using Microsoft.AspNetCore.Mvc;
using OSIRIS.Common;
using OSIRIS.Common.Helpers;
using OSIRIS.Common.Requests;
using OSIRIS.Common.Responses;
using OSIRIS.Common.Services.Auth;
using System.Threading.Tasks;

namespace OSIRIS.Api.Controllers.V1
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService identityService)
        {
            _authService = identityService;
        }

        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Returns Auth Results</response>
        /// <response code="500">If Register fails</response>   
        [HttpPost(ApiRoutes.Auth.Register)]
        public async Task<ActionResult<AuthenticationResult>> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _authService.RegisterAsync(request.Email, request.Password);
            if (authResponse.Success)
            {
                return Ok(authResponse);
            }
            return BadRequest();
        }

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <response code="200">Returns Auth Results</response>
        /// <response code="500">If Login fails</response>  
        [HttpPost(ApiRoutes.Auth.Login)]
        public async Task<ActionResult<AuthenticationResult>> Login([FromBody] UserLoginRequest request)
        {
            var authResponse = await _authService.LoginAsync(request.Email, request.Password);

            if (authResponse.Success)
            {
                return Ok(authResponse);
            }
            return BadRequest();
        }


        }
}
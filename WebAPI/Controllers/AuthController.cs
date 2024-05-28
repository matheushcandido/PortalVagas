using Application.DTOs;
using Application.UseCases.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDTO userLogin)
        {
            var user = new AuthenticationCommand { Email = userLogin.Email, Password = userLogin.Password };
            var response = await _mediator.Send(user);

            if (response.IsSuccess)
            {
                return StatusCode((int)response.StatusCode, response.Response);
            }

            return Ok(new { Token = response.Response });
        }
    }
}

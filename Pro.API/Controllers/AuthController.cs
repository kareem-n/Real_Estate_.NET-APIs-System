using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pro.API.Extentions;
using Pro.Application.DTOs.Auth;
using Pro.Application.UseCases.Auth.Commands.UserLogin;
using Pro.Application.UseCases.Auth.Commands.UserRegister;
namespace Pro.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Get([FromBody] LoginRequest loginRequest)
        {
            var r = await _mediator.Send(new UserLoginQuery(loginRequest));
            return r.ToActionResult();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterNewUserDto registerNewUserDto)
        {
            var result = await _mediator.Send(new CreateUserCommand(registerNewUserDto));
            return result.ToActionResult();

        }
    }
}

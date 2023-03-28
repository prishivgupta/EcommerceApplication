using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Users.Commands.AuthCommands;
using Users.Commands.UserCommands;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("LoginUser")]
        public IActionResult Login([FromBody] UserDTO user)
        {
            var users = _mediator.Send(new LoginUserCommand(user));
            return Ok(users);

        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody] Tuser user)
        {
            var users = await _mediator.Send(new RegisterUserCommand(user));
            return Ok(users);
        }
    }
}

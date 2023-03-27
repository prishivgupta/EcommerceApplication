using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Users.Commands.UserCommands;
using Users.Queries;

namespace Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<ActionResult> GetuserById(int id)
        {
            var user = await mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult> AddUser([FromBody] Tuser user)
        {
            await mediator.Send(new AddUserCommand(user));
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult> UpdateUser([FromBody] Tuser user)
        {
            await mediator.Send(new UpdateUserCommand(user));
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await mediator.Send(new DeleteUserCommand(id));
            return StatusCode(201);
        }
    }
}

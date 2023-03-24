﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Users.Commands.AuthCommands;

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
        public IActionResult Login([FromBody] UserDTO user)
        {
            var users = _mediator.Send(new LoginUserCommand(user));
            return Ok(users);

        }
    }
}

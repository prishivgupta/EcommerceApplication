using MediatR;
using Products.Models;

namespace Users.Commands.AuthCommands
{
    public record RegisterUserCommand(Tuser user) : IRequest<UserDTO>
    {
    }
}

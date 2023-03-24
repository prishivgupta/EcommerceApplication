using MediatR;
using Products.Models;

namespace Users.Commands.UserCommands
{
    public record AddUserCommand(Tuser user) : IRequest<List<Tuser>>
    {
    }
}

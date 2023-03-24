using MediatR;

namespace Users.Commands.UserCommands
{
    public record DeleteUserCommand(int id) : IRequest<string>
    {
    }
}

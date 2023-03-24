using MediatR;

namespace Users.Commands.AuthCommands
{
    public record LoginUserCommand(UserDTO user) : IRequest<UserDTO>
    {
    }
}

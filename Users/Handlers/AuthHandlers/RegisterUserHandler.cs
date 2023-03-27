using MediatR;
using Products.Models;
using Users.Commands.AuthCommands;
using Users.DataAccess.Interfaces;

namespace Users.Handlers.AuthHandlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserDTO>
    {
        private readonly IAuth _auth;

        public RegisterUserHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _auth.RegisterUser(request.user));
        }
    }
}

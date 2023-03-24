using MediatR;
using Users.Commands.AuthCommands;
using Users.DataAccess.Interfaces;

namespace Users.Handlers.AuthHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, UserDTO>
    {
        private readonly IAuth _auth;

        public LoginUserHandler(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<UserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_auth.LoginUser(request.user));
        }
    }
}

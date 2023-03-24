using MediatR;
using NuGet.Protocol.Plugins;
using Users.Commands.UserCommands;
using Users.DataAccess.Interfaces;

namespace Users.Handlers.UserHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IUser _user;

        public DeleteUserHandler(IUser user)
        {
            _user = user;
        }
        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _user.DeleteUSer(request.id));
        }
    }
}

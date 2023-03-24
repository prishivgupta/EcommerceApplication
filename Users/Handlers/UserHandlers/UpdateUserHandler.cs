using MediatR;
using NuGet.Protocol.Plugins;
using Products.Models;
using Users.Commands.UserCommands;
using Users.DataAccess.Interfaces;

namespace Users.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, List<Tuser>>
    {

        private readonly IUser _user;

        public UpdateUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<List<Tuser>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _user.UpdateUser(request.user));
        }
    }
}

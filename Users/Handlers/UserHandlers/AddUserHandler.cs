using MediatR;
using NuGet.Protocol.Plugins;
using Products.Models;
using Users.Commands.UserCommands;
using Users.DataAccess.Interfaces;

namespace Users.Handlers.UserHandlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, List<Tuser>>
    {
        private readonly IUser _user;


        public AddUserHandler(IUser user)
        {
            _user = user;
        }

        public async Task<List<Tuser>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _user.AddUser(request.user));
        }
    }
}

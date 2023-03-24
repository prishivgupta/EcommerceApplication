using MediatR;
using NuGet.Protocol.Plugins;
using Products.Models;
using Users.DataAccess.Interfaces;
using Users.Queries;

namespace Users.Handlers.UserHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<Tuser>>
    {
        private readonly IUser _user;

        public GetAllUsersHandler(IUser user)
        {
            _user = user;
        }
        public async Task<List<Tuser>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _user.GetAllUsers());
        }
    }
}

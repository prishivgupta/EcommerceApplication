using MediatR;
using NuGet.Protocol.Plugins;
using Products.Models;
using Users.DataAccess.Interfaces;
using Users.Queries;

namespace Users.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, Tuser>
    {
        private readonly IUser _user;

        public GetUserByIdHandler(IUser user)
        {
            _user = user;
        }
        public async Task<Tuser> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _user.GetUserById(request.id));
        }
    }
}

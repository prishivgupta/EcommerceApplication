using MediatR;
using Products.Models;

namespace Users.Queries
{
    public record GetAllUsersQuery : IRequest<List<Tuser>>
    {
    }
}

using MediatR;
using Products.Models;

namespace Users.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<Tuser>
    {
    }
}

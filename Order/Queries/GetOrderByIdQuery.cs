using MediatR;
using Products.Models;

namespace Order.Queries
{
    public record GetOrderByIdQuery(int id) : IRequest<Torder>
    {
    }
}

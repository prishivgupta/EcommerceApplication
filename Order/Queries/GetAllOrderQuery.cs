using MediatR;
using Products.Models;

namespace Order.Queries
{
    public record GetAllOrdersQuery : IRequest<List<Torder>>
    {

    }
}

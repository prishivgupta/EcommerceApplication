using MediatR;
using Products.Models;

namespace Order.Queries
{
    public record GetMyOrdersQuery(int id) :IRequest<List<Torder>>
    {
    }
}

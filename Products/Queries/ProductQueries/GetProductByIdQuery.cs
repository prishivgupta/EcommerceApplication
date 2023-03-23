using MediatR;
using Products.Models;

namespace Products.Queries.ProductQueries
{
    public record GetProductByIdQuery(int id) : IRequest<Tproduct>
    {
    }
}

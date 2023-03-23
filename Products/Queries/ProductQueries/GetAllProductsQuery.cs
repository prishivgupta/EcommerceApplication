
using MediatR;
using Products.Models;

namespace Products.Queries.ProductQueries
{
    public record GetAllProductsQuery : IRequest<List<Tproduct>>
    {
    }
}

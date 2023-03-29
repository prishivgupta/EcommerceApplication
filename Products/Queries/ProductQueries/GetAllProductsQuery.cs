
using MediatR;
using Products.Models;

namespace Products.Queries.ProductQueries
{
    public record GetAllProductsQuery(int? categoryId, string? search) : IRequest<List<Tproduct>>
    {
    }
}

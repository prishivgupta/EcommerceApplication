using MediatR;
using Products.Models;

namespace Products.Queries.CategoryQueries
{
    public record GetAllCategoriesQuery : IRequest<List<Tcategory>>
    {
    }
}

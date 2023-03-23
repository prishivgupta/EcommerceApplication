using MediatR;
using Products.Models;

namespace Products.Queries.CategoryQueries
{
    public record GetCategoryByIdQuery(int id) : IRequest<Tcategory>
    {
    }
}

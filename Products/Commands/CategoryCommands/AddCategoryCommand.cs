using MediatR;
using Products.Models;

namespace Products.Commands.CategoryCommands
{
    public record AddCategoryCommand(Tcategory category) : IRequest<List<Tcategory>>
    {
    }
}

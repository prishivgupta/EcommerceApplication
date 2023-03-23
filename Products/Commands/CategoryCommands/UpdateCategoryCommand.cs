using MediatR;
using Products.Models;

namespace Products.Commands.CategoryCommands
{
    public record UpdateCategoryCommand(Tcategory category) : IRequest<List<Tcategory>>
    {
    }
}

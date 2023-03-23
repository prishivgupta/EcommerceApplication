using MediatR;
using Products.Models;

namespace Products.Commands.ProductCommands
{
    public record UpdateProductCommand(Tproduct product) : IRequest<List<Tproduct>>
    {
    }
}

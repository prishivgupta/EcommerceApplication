using MediatR;
using Products.Models;

namespace Products.Commands.ProductCommands
{
    public record AddProductCommand(Tproduct product) : IRequest<List<Tproduct>>
    {
    }
}

using MediatR;

namespace Products.Commands.ProductCommands
{
    public record DeleteProductCommand(int id) : IRequest<string>
    {
    }
}

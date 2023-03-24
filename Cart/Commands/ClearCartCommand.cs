using MediatR;

namespace Cart.Commands
{
    public record ClearCartCommand(int cartId) : IRequest<string>
    {
    }
}

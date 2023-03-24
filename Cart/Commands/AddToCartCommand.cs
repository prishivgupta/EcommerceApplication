using MediatR;
using Cart.Models;

namespace Cart.Commands
{
    public record AddToCartCommand(TcartItem cartItem) : IRequest<TcartItem>
    {
    }
}

using MediatR;
using Products.Models;

namespace Cart.Commands
{
    public record AddToCartCommand(TcartItem cartItem) : IRequest<TcartItem>
    {
    }
}

using Cart.Commands;
using Cart.DataAccess.Interfaces;
using MediatR;
using Cart.Models;

namespace Cart.Handlers
{
    public class AddToCartHandler : IRequestHandler<AddToCartCommand, TcartItem>
    {
        private readonly ICart cart;

        public AddToCartHandler(ICart cart)
        {
            this.cart = cart;
        }

        public async Task<TcartItem> Handle(AddToCartCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await cart.AddToCart(request.cartItem));
        }
    }
}

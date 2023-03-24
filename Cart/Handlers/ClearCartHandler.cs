using Cart.Commands;
using Cart.DataAccess.Interfaces;
using MediatR;

namespace Cart.Handlers
{
    public class ClearCartHandler : IRequestHandler<ClearCartCommand, string>
    {
        private readonly ICart cart;

        public ClearCartHandler(ICart cart)
        {
            this.cart = cart;
        }

        public async Task<string> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await cart.ClearCart(request.cartId));
        }
    }
}

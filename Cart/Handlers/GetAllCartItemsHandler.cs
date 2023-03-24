using Cart.DataAccess.Interfaces;
using Cart.Queries;
using MediatR;
using Cart.Models;

namespace Cart.Handlers
{
    public class GetAllCartItemsHandler : IRequestHandler<GetAllCartItemsQuery, List<TcartItem>>
    {
        private readonly ICart cart;

        public GetAllCartItemsHandler (ICart cart)
        {
            this.cart = cart;
        }

        public async Task<List<TcartItem>> Handle(GetAllCartItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await cart.GetAllCartItems(request.cartId));
        }
    }
}

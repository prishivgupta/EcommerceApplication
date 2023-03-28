using MediatR;
using Products.Models;

namespace Cart.Queries
{
    public record GetAllCartItemsQuery(int cartId) : IRequest<List<TcartItem>>
    {
    }
}

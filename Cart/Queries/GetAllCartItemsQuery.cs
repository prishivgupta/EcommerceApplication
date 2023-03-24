using MediatR;
using Cart.Models;

namespace Cart.Queries
{
    public record GetAllCartItemsQuery(int cartId) : IRequest<List<TcartItem>>
    {
    }
}

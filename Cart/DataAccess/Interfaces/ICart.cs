using Products.Models;

namespace Cart.DataAccess.Interfaces
{
    public interface ICart
    {
        public Task<TcartItem> AddToCart(TcartItem cartItem);

        public Task<List<TcartItem>> GetAllCartItems(int cartId);

        public Task<string> ClearCart(int cartId);
    }
}

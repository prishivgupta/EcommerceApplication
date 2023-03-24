using Cart.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Cart.DataAccess;
using Cart.Models;

namespace Cart.Repositories
{
    public class CartRepository : ICart
    {
        private readonly EcommerceContext _ecommerceContext;

        public CartRepository (EcommerceContext context)
        {
            _ecommerceContext = context;
        }

        public async Task<TcartItem> AddToCart(TcartItem cartItem)
        {
            try
            {
                var isItemAdded = await _ecommerceContext.TcartItems.Where(i => i.CartId == cartItem.CartId && i.ProductId == cartItem.ProductId).FirstOrDefaultAsync();

                var cart = await _ecommerceContext.Tcarts.Where(c => c.CartId == cartItem.CartId).FirstOrDefaultAsync();
                var product = await _ecommerceContext.Tproducts.Where(c => c.ProductId == cartItem.ProductId).FirstOrDefaultAsync();

                if (isItemAdded == null)
                {
                    await _ecommerceContext.TcartItems.AddAsync(cartItem);
                    await _ecommerceContext?.SaveChangesAsync();

                    cart.TotalCost = cart.TotalCost + (product.ProductPrice * cartItem.ProductQuantity);
                    cart.Discount = cart.Discount + (product.ProductDiscountedPrice * cartItem.ProductQuantity);
                    await _ecommerceContext.SaveChangesAsync();

                    return cartItem;
                }
                else
                {
                    if (cartItem.ProductQuantity == 0)
                    {
                        _ecommerceContext.TcartItems.Remove(isItemAdded);
                        await _ecommerceContext?.SaveChangesAsync();

                        cart.TotalCost = cart.TotalCost - (product.ProductPrice * isItemAdded.ProductQuantity);
                        cart.Discount = cart.Discount - (product.ProductDiscountedPrice * isItemAdded.ProductQuantity);
                        await _ecommerceContext.SaveChangesAsync();
                    }
                    else
                    {
                        cart.TotalCost = cart.TotalCost + (product.ProductPrice * (cartItem.ProductQuantity - isItemAdded.ProductQuantity));
                        cart.Discount = cart.Discount + (product.ProductDiscountedPrice * (cartItem.ProductQuantity - isItemAdded.ProductQuantity));

                        isItemAdded.ProductQuantity = cartItem.ProductQuantity;

                        await _ecommerceContext.SaveChangesAsync();
                    }
                    

                    await _ecommerceContext.SaveChangesAsync();
                    return isItemAdded;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<string> ClearCart(int cartId)
        {
            try
            {
                _ecommerceContext.TcartItems.RemoveRange(_ecommerceContext.TcartItems.Where(t => t.CartId == cartId));

                var cart = await _ecommerceContext.Tcarts.Where(c => c.CartId == cartId).FirstOrDefaultAsync();

                if (cart != null)
                {
                    cart.TotalCost = 0;
                    cart.Discount = 0;
                }

                await _ecommerceContext.SaveChangesAsync();
                return "Cart Cleared Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TcartItem>> GetAllCartItems(int cartId)
        {
            try
            {
                return await _ecommerceContext.TcartItems.Where(t => t.CartId == cartId).Include(c => c.Product).Include(c => c.Cart).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}

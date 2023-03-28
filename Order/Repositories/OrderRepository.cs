using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Interfaces;
using Products.DataAccess;
using Products.Models;

namespace Order.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly EcommerceContext _ecommerceContext;

        public OrderRepository(EcommerceContext ecommerceContext)
        {
            _ecommerceContext = ecommerceContext;
        }

        public async Task<List<Torder>> PlaceOrder(Torder order)
        {
            try
            {
                _ecommerceContext?.Torders.AddAsync(order);
                await _ecommerceContext?.SaveChangesAsync();
                return await _ecommerceContext.Torders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteOrder(int id)
        {
            try
            {
                var order = await _ecommerceContext.Torders.FindAsync(id);

                if (order != null)
                {
                    _ecommerceContext.Torders.Remove(order);
                    await _ecommerceContext.SaveChangesAsync();
                    return "Deleted Successfully";
                }
                else
                {
                    return "Record Not Found";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Torder>> GetAllOrders()
        {
            try
            {
                return await _ecommerceContext.Torders.Include(p => p.Cart).Include(x => x.User).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Torder> GetOrderById(int id)
        {
            try
            {
                var order = await _ecommerceContext.Torders.Where(j => j.OrderId == id).Include(p => p.Cart).Include(x => x.User).FirstOrDefaultAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Torder>> UpdateOrder(Torder order)
        {
            try
            {
                var p = await _ecommerceContext.Torders.FindAsync(order.OrderId);

                if (p != null)
                {
                    p.OrderStatus = order.OrderStatus;
                    p.ShipmentAddress = order.ShipmentAddress;
                    p.CartId = order.CartId;
                    p.UserId = order.UserId;
                    p.DateOfPurchase = order.DateOfPurchase;

                    await _ecommerceContext.SaveChangesAsync();
                }

                await _ecommerceContext.SaveChangesAsync();
                return await _ecommerceContext.Torders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public  List<Torder> GetAllMyOrders(int id)
        {
           return  _ecommerceContext.Torders.Where(x => x.UserId==id).ToList();
            
        }
    }
}

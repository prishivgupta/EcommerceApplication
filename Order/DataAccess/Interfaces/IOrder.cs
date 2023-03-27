using Products.Models;

namespace Order.DataAccess.Interfaces
{
    public interface IOrder
    {
        public Task<List<Torder>> PlaceOrder(Torder order);

        public Task<List<Torder>> UpdateOrder(Torder order);

        public Task<List<Torder>> GetAllOrders();

        public Task<string> DeleteOrder(int id);

        public Task<Torder> GetOrderById(int id);

    }
}

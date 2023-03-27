using MediatR;
using Order.Commands;
using Order.DataAccess.Interfaces;
using Products.Models;

namespace Order.Handlers
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrderCommand, List<Torder>>
    {
        private readonly IOrder _order;

        public PlaceOrderHandler(IOrder order)
        {
            _order = order;
        }

        public async Task<List<Torder>> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _order.PlaceOrder(request.order));
        }
    }
}

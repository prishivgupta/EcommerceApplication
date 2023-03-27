using MediatR;
using NuGet.Protocol.Plugins;
using Order.Commands;
using Order.DataAccess.Interfaces;
using Products.Models;

namespace Order.Handlers
{
    public class UpdateOrderHandler :IRequestHandler<UpdateOrderCommand,List<Torder>>
    {
        private readonly IOrder _order;

        public UpdateOrderHandler(IOrder order)
        {
            _order = order;
        }

        public async Task<List<Torder>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _order.UpdateOrder(request.order));
        }
    }
}

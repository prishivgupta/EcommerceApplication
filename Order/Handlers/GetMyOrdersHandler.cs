using MediatR;
using NuGet.Protocol.Plugins;
using Order.DataAccess.Interfaces;
using Order.Queries;
using Products.Models;

namespace Order.Handlers
{
    public class GetMyOrdersHandler :IRequestHandler<GetMyOrdersQuery,List<Torder>>
    {
        private readonly IOrder _order;


        public GetMyOrdersHandler(IOrder order)
        {
            _order = order;
        }

        public Task<List<Torder>> Handle(GetMyOrdersQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_order.GetAllMyOrders(request.id));
        }
    }
}

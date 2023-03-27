using MediatR;
using NuGet.Protocol.Plugins;
using Order.DataAccess.Interfaces;
using Order.Queries;
using Products.Models;

namespace Order.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<Torder>>
    {
        private readonly IOrder _order;

        public GetAllOrdersHandler(IOrder order)
        {
            _order = order;
        }

        public async  Task<List<Torder>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return  await Task.FromResult( await _order.GetAllOrders());
        }
    }
}

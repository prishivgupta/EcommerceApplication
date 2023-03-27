using MediatR;
using NuGet.Protocol.Plugins;
using Order.DataAccess.Interfaces;
using Order.Queries;
using Products.Models;

namespace Order.Handlers
{
    public class GetOrderByIdHandler:IRequestHandler<GetOrderByIdQuery,Torder>
    {
        private readonly IOrder _order;

        public GetOrderByIdHandler(IOrder order)
        {
            _order = order;
        }

        public async Task<Torder> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _order.GetOrderById(request.id));
        }
    }
}

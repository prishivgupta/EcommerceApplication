using MediatR;
using NuGet.Protocol.Plugins;
using Order.Commands;
using Order.DataAccess.Interfaces;

namespace Order.Handlers
{
    public class DeleteOrderhandler :IRequestHandler<DeleteOrderCommand,string>
    {
        private readonly IOrder _order;

        public DeleteOrderhandler(IOrder order)
        {
            _order = order;
        }

        public async Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _order.DeleteOrder(request.id));
        }
    }
}

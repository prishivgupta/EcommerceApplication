using MediatR;
using Products.Models;

namespace Order.Commands
{
    public record PlaceOrderCommand(Torder order):IRequest<List<Torder>>
    {
    }
}

using MediatR;
using Products.Models;

namespace Order.Commands
{
    public record UpdateOrderCommand(Torder order):IRequest<List<Torder>>
    {
    }
}

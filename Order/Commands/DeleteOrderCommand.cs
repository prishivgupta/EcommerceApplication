using MediatR;

namespace Order.Commands
{
    public record DeleteOrderCommand(int id):IRequest<string>
    {
    }
}

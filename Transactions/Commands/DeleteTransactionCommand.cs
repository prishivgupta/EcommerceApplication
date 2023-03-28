using MediatR;

namespace Payment.Commands
{
    public record DeleteTransactionCommand(string id):IRequest<string>
    {
    }
}

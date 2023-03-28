using Amazon.Runtime.Internal;
using MediatR;
using Payment.Models;

namespace Payment.Commands
{
    public record UpdateTransactionCommand(string id,TransactionDetails payment):IRequest<string>
    {
    }
}

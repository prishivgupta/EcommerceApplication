using MediatR;
using Payment.Models;

namespace Transactions.Commands
{
    public record AddTransactionCommand(TransactionDetails transaction):IRequest<string>
    {
    }
}

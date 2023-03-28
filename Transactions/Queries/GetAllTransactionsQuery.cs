using Amazon.Runtime.Internal;
using MediatR;
using Payment.Models;

namespace Payment.Queries
{
    public record GetAllTransactionsQuery :IRequest<List<TransactionDetails>>
    {
    }
}

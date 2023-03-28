using Amazon.Runtime.Internal;
using MediatR;
using Payment.Models;

namespace Payment.Queries
{
    public record GetTransactionByIdQuery(string id):IRequest<TransactionDetails>
    {
    }
}

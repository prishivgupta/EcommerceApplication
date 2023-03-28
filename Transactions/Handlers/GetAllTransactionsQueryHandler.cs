using MediatR;
using Payment.Interface;
using Payment.Models;
using Payment.Queries;

namespace Payment.Handlers
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDetails>>
    {
        private readonly ITransaction _payment;

        public GetAllTransactionsQueryHandler(ITransaction payment)
        {
            _payment = payment;
        }

        public  Task<List<TransactionDetails>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult( _payment.GetAllTransactions());
        }
    }
}

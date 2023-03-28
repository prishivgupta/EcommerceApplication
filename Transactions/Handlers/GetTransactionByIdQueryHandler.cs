using MediatR;
using Payment.Interface;
using Payment.Models;
using Payment.Queries;

namespace Payment.Handlers
{
    public class GetTransactionByIdQueryHandler :IRequestHandler<GetTransactionByIdQuery,TransactionDetails>
    {
        private readonly ITransaction _payment;

        public GetTransactionByIdQueryHandler(ITransaction payment)
        {
            _payment = payment;
        }

        public  Task<TransactionDetails> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            return  Task.FromResult( _payment.GetTransactionById(request.id));
        }
    }
}

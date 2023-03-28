using MediatR;
using Payment.Interface;
using Transactions.Commands;

namespace Transactions.Handlers
{
    public class AddTransactionHandler :IRequestHandler<AddTransactionCommand,string>
    {
        private readonly ITransaction _transaction;

        public AddTransactionHandler(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<string> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult( await _transaction.CreateAsync(request.transaction));
        }
    }
}

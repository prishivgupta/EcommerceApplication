using MediatR;
using Payment.Commands;
using Payment.Interface;

namespace Payment.Handlers
{
    public class DeleteTransactionCommandHandler :IRequestHandler<DeleteTransactionCommand,string>
    {
        private readonly ITransaction _payment;

        public DeleteTransactionCommandHandler(ITransaction payment)
        {
            _payment = payment;
        }

        public async Task<string> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _payment.RemoveAsync(request.id));
        }
    }
}

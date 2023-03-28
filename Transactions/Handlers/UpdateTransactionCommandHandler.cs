using MediatR;
using Payment.Commands;
using Payment.Interface;

namespace Payment.Handlers
{
    public class UpdateTransactionCommandHandler :IRequestHandler<UpdateTransactionCommand,string>
    {
        private readonly ITransaction _payment;

        public UpdateTransactionCommandHandler(ITransaction payment)
        {
            _payment=payment;
        }

        public async Task<string> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await _payment.UpdateAsync(request.id,request.payment));
        }
    }
}

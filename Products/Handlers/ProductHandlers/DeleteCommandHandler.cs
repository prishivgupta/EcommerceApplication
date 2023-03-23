using MediatR;
using Products.Commands.ProductCommands;
using Products.DataAccess.Interface;

namespace Products.Handlers.ProductHandlers
{
    public class DeleteCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProduct product;

        public DeleteCommandHandler(IProduct product)
        {
            this.product = product;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await product.DeleteProduct(request.id));
        }
    }
}

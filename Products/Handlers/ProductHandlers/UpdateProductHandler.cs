using MediatR;
using NuGet.Protocol.Plugins;
using Products.Commands.ProductCommands;
using Products.DataAccess.Interface;
using Products.Models;

namespace Products.Handlers.ProductHandlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, List<Tproduct>>
    {
        private readonly IProduct product;

        public UpdateProductHandler(IProduct product)
        {
            this.product = product;
        }

        public async Task<List<Tproduct>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await product.UpdateProduct(request.product));
        }
    }
}

using MediatR;
using NuGet.Protocol.Plugins;
using Products.Commands.ProductCommands;
using Products.DataAccess.Interface;
using Products.Models;

namespace Products.Handlers.ProductHandlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, List<Tproduct>>
    {
        private readonly IProduct product;

        public AddProductHandler (IProduct product)
        {
            this.product = product;
        }

        public async  Task<List<Tproduct>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await product.AddProduct(request.product));
        }
    }
}

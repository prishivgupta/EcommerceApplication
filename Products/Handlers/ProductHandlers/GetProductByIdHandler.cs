using MediatR;
using Products.DataAccess.Interface;
using Products.Models;
using Products.Queries.ProductQueries;

namespace Products.Handlers.ProductHandlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Tproduct>
    {
        private readonly IProduct product;

        public GetProductByIdHandler(IProduct product)
        {
            this.product = product;
        }

        public async Task<Tproduct> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await product.GetProductById(request.id));
        }
    }
}

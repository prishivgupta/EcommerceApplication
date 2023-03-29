using MediatR;
using Products.DataAccess.Interface;
using Products.Models;
using Products.Queries.ProductQueries;

namespace Products.Handlers.ProductHandlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Tproduct>>
    {
        private readonly IProduct product;

        public GetAllProductsHandler(IProduct product)
        {
            this.product = product;
        }

        public async Task<List<Tproduct>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await product.GetAllProducts(request.categoryId, request.search));
        }
    }
}

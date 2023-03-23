using MediatR;
using NuGet.Protocol.Plugins;
using Products.DataAccess.Interface;
using Products.Models;
using Products.Queries.CategoryQueries;

namespace Products.Handlers.CategoryHandlers
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, Tcategory>
    {
        private readonly ICategory category;

        public GetCategoryByIdHandler(ICategory category)
        {
            this.category = category;
        }

        public async Task<Tcategory> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await category.GetCategoryById(request.id));
        }
    }
}

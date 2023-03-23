using MediatR;
using NuGet.Protocol.Plugins;
using Products.DataAccess.Interface;
using Products.Models;
using Products.Queries.CategoryQueries;

namespace Products.Handlers.CategoryHandlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, List<Tcategory>>
    {
        private readonly ICategory category;

        public GetAllCategoriesHandler(ICategory category)
        {
            this.category = category;
        }

        public async Task<List<Tcategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await category.GetAllCategories());
        }
    }
}

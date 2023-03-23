using MediatR;
using NuGet.Protocol.Plugins;
using Products.Commands.CategoryCommands;
using Products.DataAccess.Interface;
using Products.Models;

namespace Products.Handlers.CategoryHandlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, List<Tcategory>>
    {
        private readonly ICategory category;

        public UpdateCategoryHandler(ICategory category)
        {
            this.category = category;
        }

        public async Task<List<Tcategory>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await category.UpdateCategory(request.category));
        }
    }
}

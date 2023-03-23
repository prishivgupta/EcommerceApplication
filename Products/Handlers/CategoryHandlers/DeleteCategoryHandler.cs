using MediatR;
using NuGet.Protocol.Plugins;
using Products.Commands.CategoryCommands;
using Products.DataAccess.Interface;

namespace Products.Handlers.CategoryHandlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly ICategory category;

        public DeleteCategoryHandler(ICategory category)
        {
            this.category = category;
        }

        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await category.DeleteCategory(request.id));
        }
    }
}

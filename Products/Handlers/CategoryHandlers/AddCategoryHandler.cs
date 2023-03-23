using MediatR;
using Products.Commands.CategoryCommands;
using Products.DataAccess.Interface;
using Products.Models;

namespace Products.Handlers.CategoryHandlers
{
    public class AddCategoryHandler : IRequestHandler<AddCategoryCommand, List<Tcategory>>
    {
        private readonly ICategory category;

        public AddCategoryHandler(ICategory category)
        {
            this.category = category;
        }

        public async Task<List<Tcategory>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(await category.AddCategory(request.category));
        }
    }
}

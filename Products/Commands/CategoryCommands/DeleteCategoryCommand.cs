using MediatR;

namespace Products.Commands.CategoryCommands
{
    public record DeleteCategoryCommand(int id) : IRequest<string>
    {
    }
}

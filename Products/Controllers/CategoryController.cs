using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Commands.CategoryCommands;
using Products.Models;
using Products.Queries.CategoryQueries;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet]
        [Route("GetCategoryById/{id}")]

        public async Task<ActionResult> GetCategoryById(int id)
        {
            var category = await mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(category);
        }

        [HttpPost]
        [Route("AddCategory")]

        public async Task<ActionResult> AddCategory([FromBody] Tcategory category)
        {
            await mediator.Send(new AddCategoryCommand(category));
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateCategory")]

        public async Task<ActionResult> UpdateCategory([FromBody] Tcategory category)
        {
            await mediator.Send(new UpdateCategoryCommand(category));
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]

        public async Task<ActionResult> DeleteCategory(int id)
        {
            await mediator.Send(new DeleteCategoryCommand(id));
            return StatusCode(201);
        }
    }
}

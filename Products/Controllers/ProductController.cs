using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.Commands.CategoryCommands;
using Products.Commands.ProductCommands;
using Products.Models;
using Products.Queries.CategoryQueries;
using Products.Queries.ProductQueries;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet]
        [Route("GetProductById/{id}")]

        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        [Route("AddProduct")]

        public async Task<ActionResult> AddProduct([FromBody] Tproduct product)
        {
            await mediator.Send(new AddProductCommand(product));
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateProduct")]

        public async Task<ActionResult> UpdateProduct([FromBody] Tproduct product)
        {
            await mediator.Send(new UpdateProductCommand(product));
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]

        public async Task<ActionResult> DeleteProduct(int id)
        {
            await mediator.Send(new DeleteProductCommand(id));
            return StatusCode(201);
        }
    }
}

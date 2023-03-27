using Cart.Commands;
using Cart.Models;
using Cart.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllCartItems/{cartId}")]
        public async Task<IActionResult> GetAllCartItems(int cartId)
        {
            var cartItems = await mediator.Send(new GetAllCartItemsQuery(cartId));
            return Ok(cartItems);
        }

        [HttpPost]
        [Route("AddToCart")]

        public async Task<ActionResult> AddToCart([FromBody] TcartItem cartItem)
        {
            var c = await mediator.Send(new AddToCartCommand(cartItem));
            return Ok(c);
        }

        [HttpPost]
        [Route("ClearCart")]

        public async Task<ActionResult> ClearCart([FromBody] int cartId)
        {
            await mediator.Send(new ClearCartCommand(cartId));
            return StatusCode(201);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Commands;
using Order.Queries;
using Products.Models;

namespace Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _mediator.Send(new GetAllOrdersQuery());
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]

        public async Task<ActionResult> GetOrderById(int id)
        {
            var product = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        [Route("PlaceOrder")]

        public async Task<ActionResult> PlaceOrder([FromBody] Torder order)
        {
            await _mediator.Send(new PlaceOrderCommand(order));
            return StatusCode(201);
        }

        [HttpPut]
        [Route("UpdateOrder")]

        public async Task<ActionResult> UpdateOrder([FromBody] Torder order)
        {
            await _mediator.Send(new UpdateOrderCommand(order));
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("DeleteOrder/{id}")]

        public async Task<ActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return StatusCode(201);
        }
    }
}

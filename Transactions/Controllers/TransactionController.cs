using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Commands;
using Payment.Models;
using Payment.Queries;
using Payment.Repository;

namespace Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

       
        [HttpGet]
        [Route("getAllTransactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var employees = await _mediator.Send(new GetAllTransactionsQuery());
            return Ok(employees);
        }

        [HttpGet]
        [Route("getTransactionById/{id}")]
        public async Task<IActionResult> GetTransactionByid(string id)
        {
            var employees = await _mediator.Send(new GetTransactionByIdQuery(id));
            return Ok(employees);
        }


        [HttpDelete]
        [Route("deleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(string id)
        {
            await _mediator.Send(new DeleteTransactionCommand(id));
            return StatusCode(200);
        }

        [HttpPut]
        [Route("updateTransaction/{id}")]
        public async Task<IActionResult> UpdateTransaction(string id, [FromBody] TransactionDetails payment)
        {
            await _mediator.Send(new UpdateTransactionCommand(id, payment));
            return StatusCode(201);
        }
    }
}

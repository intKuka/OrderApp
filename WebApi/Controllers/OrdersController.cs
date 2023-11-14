using Application.Commands.CreateOrderCommand;
using Application.Commands.DeleteOrderCommand;
using Application.Commands.UpdateOrderCommand;
using Application.Queries.GetAllOrdersQuery;
using Application.Queries.GetOrderQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Orders
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllOrdersRequest());
            return View(result);
        }

        // GET: Orders/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _mediator.Send(new GetOrderRequest(id));
            return result == null ? 
                RedirectToAction(nameof(Index)) : 
                View(result);
        }

        // GET: Orders/New
        [HttpGet("New")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders
        [HttpPost("New")]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        // PUT: Orders/5
        [HttpPost("{id:int}")]
        public async Task<IActionResult> Edit(int id, UpdateOrderCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }

        // GET: Orders/5
        [HttpGet("{id:int}/Confirmation")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new GetOrderRequest(id));
            return result == null ?
                RedirectToAction(nameof(Index)) :
                View(result);
        }

        // DELETE: Orders/5
        [HttpPost("{id:int}/Confirmation"), ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var command = new DeleteOrderCommand { Id = id };
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}

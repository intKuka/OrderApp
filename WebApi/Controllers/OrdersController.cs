using Application.CQRS.Orders.Commands.CreateOrder;
using Application.CQRS.Orders.Commands.DeleteOrder;
using Application.CQRS.Orders.Commands.UpdateOrder;
using Application.CQRS.Orders.Queries.GetOrderCreateView;
using Application.CQRS.Orders.Queries.GetOrderDetailsView;
using Application.CQRS.Orders.Queries.GetOrderEditView;
using Application.CQRS.Orders.Queries.GetOrderListView;
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
        public async Task<IActionResult> Index([FromQuery]OrderListFilter filter)
        {
            var query = new GetOrderListViewQuery(filter);
            var result = await _mediator.Send(query);
            return View(result);
        }

        // GET: Orders/5/Details
        [HttpGet("{id:int}/Details")]
        public async Task<IActionResult> Details(int id)
        {
            var result = await _mediator.Send(new GetOrderDetailsViewQuery(id));
            return View(result);
        }

        // GET: Orders/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _mediator.Send(new GetOrderEditViewQuery(id));
            return View(result);
        }

        // GET: Orders/New
        [HttpGet("New")]
        public async Task<IActionResult> Create()
        {
            var viewModel = await _mediator.Send(new GetOrderCreateViewQuery());
            return View(viewModel);
        }

        // POST: Orders/New
        [HttpPost("New")]
        public async Task<IActionResult> Create([FromForm]CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        // POST: Orders/5
        [HttpPost("{id:int}")]
        public async Task<IActionResult> Edit(int id, [FromForm]UpdateOrderCommand command)
        {   
            command.OrderId = id;
            await _mediator.Send(command);
            return RedirectToAction(nameof(Details), new { id = command.OrderId });
        }

        // POST: Orders/5
        [HttpPost("{id:int}/Deletion")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return RedirectToAction(nameof(Index));
        }
    }
}

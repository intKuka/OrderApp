using Application.CQRS.OrderItems.Queries.GetAllOrderItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("Items")]
    public class OrderItemsController : Controller
    {
        private readonly IMediator _mediator;

        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: OrderItemsController
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllOrderItemsQuery());
            return View(result);
        }
    }
}

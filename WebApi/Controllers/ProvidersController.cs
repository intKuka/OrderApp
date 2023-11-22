using Application.CQRS.Providers.GetAllProviders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    public class ProvidersController : Controller
    {
        private readonly IMediator _mediator;

        public ProvidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: ProvidersController
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllProvidersQuery());
            return View(result);
        }
    }
}

using Domain.Models;
using MediatR;

namespace Application.Queries.GetOrderQuery
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderRequest, Order?>
    {
        private readonly IApplicationDbContext _context;

        public GetOrderQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> Handle(GetOrderRequest request, CancellationToken cancellationToken)
        {
            return await _context.Orders.FindAsync(request.Id, cancellationToken);
        }
    }
}

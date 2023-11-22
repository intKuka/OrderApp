using Application.ViewModels.Orders;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Orders.Queries.GetOrderDetailsView;

public class GetOrderDetailsViewQueryHandler : IRequestHandler<GetOrderDetailsViewQuery, OrderDetailsViewModel>
{
    private readonly IApplicationDbContext _context;

    public GetOrderDetailsViewQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderDetailsViewModel> Handle(GetOrderDetailsViewQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(p => p.OrderItems)
            .Include(p => p.Provider)
            .FirstOrDefaultAsync(o => o.OrderId == request.Id, cancellationToken);

        return new OrderDetailsViewModel
        {
            OrderId = order!.OrderId,
            Number = order.Number,
            Date = order.Date,
            Provider = order.Provider,
            OrderItems = order.OrderItems as List<OrderItem>
        };
    }
}
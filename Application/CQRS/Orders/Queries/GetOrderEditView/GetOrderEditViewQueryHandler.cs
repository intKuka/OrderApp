using Application.ViewModels.Orders;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Orders.Queries.GetOrderEditView;

public class GetOrderEditViewQueryHandler : IRequestHandler<GetOrderEditViewQuery, OrderEditViewModel>
{
    private readonly IApplicationDbContext _context;

    public GetOrderEditViewQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderEditViewModel> Handle(GetOrderEditViewQuery request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders
            .Include(p => p.OrderItems)
            .Include(p => p.Provider)
            .FirstOrDefaultAsync(x => x.OrderId == request.Id, cancellationToken);

        return new OrderEditViewModel
        {
            OrderId = order!.OrderId,
            Number = order.Number,
            Date = order.Date,
            Provider = order.Provider,
            OrderItems = order.OrderItems as List<OrderItem>,
            Providers = await _context.Providers.ToListAsync(cancellationToken)
        };

    }
}
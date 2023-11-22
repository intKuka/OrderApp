using Application.ViewModels.Orders;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Orders.Queries.GetOrderCreateView;

public class GetOrderCreateViewQueryHandler : IRequestHandler<GetOrderCreateViewQuery, OrderCreateViewModel>
{
    private readonly IApplicationDbContext _context;

    public GetOrderCreateViewQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderCreateViewModel> Handle(GetOrderCreateViewQuery request, CancellationToken cancellationToken)
    {
        var providers = await _context.Providers.ToListAsync(cancellationToken);
        return new OrderCreateViewModel
        {
            Providers = providers
        };
    }
}
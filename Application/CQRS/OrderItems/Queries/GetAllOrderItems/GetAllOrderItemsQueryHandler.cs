using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.OrderItems.Queries.GetAllOrderItems;

public class GetAllOrderItemsQueryHandler : IRequestHandler<GetAllOrderItems.GetAllOrderItemsQuery, List<OrderItem>>
{
    private readonly IApplicationDbContext _context;

    public GetAllOrderItemsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<OrderItem>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.OrderItems.ToListAsync(cancellationToken);
    }
}
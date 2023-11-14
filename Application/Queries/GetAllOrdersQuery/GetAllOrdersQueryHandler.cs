using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetAllOrdersQuery;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersRequest, List<Order>>
{
    private readonly IApplicationDbContext _context;

    public GetAllOrdersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        return await _context.Orders.ToListAsync(cancellationToken);
    }
}
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Number = request.Number,
            Date = request.Date,
            ProviderId = request.ProviderId,
            OrderItems = request.OrderItems,
        };
        
        await _context.Orders.AddRangeAsync(order);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
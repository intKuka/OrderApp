using Domain.Models;
using MediatR;

namespace Application.CQRS.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrder.UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateOrder.UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            OrderId = request.OrderId,
            Number = request.Number,
            Date = request.Date,
            ProviderId = request.ProviderId,
            OrderItems = request.OrderItems
        };

        _context.Orders.UpdateRange(order);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
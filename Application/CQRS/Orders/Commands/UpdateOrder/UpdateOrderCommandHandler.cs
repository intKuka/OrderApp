using Application.Common;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, ValidationResult>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ValidationResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            OrderId = request.OrderId,
            Number = request.Number,
            Date = request.Date,
            ProviderId = request.ProviderId,
            OrderItems = request.OrderItems
        };

        var validateNumberAndProviderId = await _context.Orders
            .AnyAsync(x => x.Number == order.Number && x.ProviderId == request.ProviderId, cancellationToken: cancellationToken);
        if (validateNumberAndProviderId) return new ValidationResult(false, "errorMessage", "Number and provider id combination must be unique");

        // who's does like that 
        var validateItemNameAndOrderNumber = order.OrderItems.Any(x => x.Name == order.Number);
        if (validateItemNameAndOrderNumber) return new ValidationResult(false, "errorMessage", "Item name can not be equal order number");


        _context.Orders.UpdateRange(order);
        await _context.SaveChangesAsync(cancellationToken);
        return new ValidationResult(true, "successMessage", "Successfully updated");
    }
}
using Application.Common;
using Application.Validators;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, CommandResult>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            OrderId = request.OrderId,
            Number = request.Number,
            Date = request.Date,
            ProviderId = request.ProviderId,
            OrderItems = request.OrderItems
        };

        var validator = new OrderValidator(_context);
        var validationResult = await validator.ValidateAsync(order, cancellationToken);
        if (!validationResult.IsValid)
            return new CommandResult(validationResult.IsValid, validationResult.Errors[0].ErrorMessage);

        _context.Orders.UpdateRange(order);
        await _context.SaveChangesAsync(cancellationToken);
        return new CommandResult(validationResult.IsValid, "Successfully updated");
        //var validateNumberAndProviderId = await _context.Orders
        //    .AnyAsync(x => x.Number == order.Number && x.ProviderId == request.ProviderId, cancellationToken: cancellationToken);
        //if (validateNumberAndProviderId) return new CommandResult(false, "Number and provider id combination must be unique");

        //// who's does like that 
        //var validateItemNameAndOrderNumber = order.OrderItems.Any(x => x.Name == order.Number);
        //if (validateItemNameAndOrderNumber) return new CommandResult(false, "Item name can not be equal order number");
    }
}
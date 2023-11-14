using Domain.Models;
using MediatR;

namespace Application.Commands.CreateOrderCommand;

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
            ProviderId = request.ProviderId
        };
        await _context.Orders.AddAsync(order, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
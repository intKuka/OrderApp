using MediatR;

namespace Application.Commands.DeleteOrderCommand;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _context.Orders.FindAsync(request.Id).Result!;
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UpdateOrderCommand;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _context.Orders.FindAsync(request.Id);
        if (order != null)
        {
            request.AlterOrder(order);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
    }
}
using Domain.Models;
using MediatR;

namespace Application.Commands.UpdateOrderCommand;

public class UpdateOrderCommand : IRequest
{
    // TODO: privatize Id property if need to 
    public int Id { get; set; }
    public string Number { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
    public int ProviderId { get; set; }

    // TODO: mapper?
    public Order AlterOrder(Order order)
    {
        order.Number = Number;
        order.Date = Date;
        order.ProviderId = ProviderId;

        return order;
    }
}
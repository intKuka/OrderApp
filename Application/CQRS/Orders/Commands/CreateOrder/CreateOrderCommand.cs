using Application.Common;
using Domain.Abstractions;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<ValidationResult>, IOrder
{
    public int OrderId { get; set; }
    public string Number { get; set; } = null!;
    public DateTime Date { get; set; }
    public int ProviderId { get; set; }
    public List<OrderItem> OrderItems{ get; set; } = new(){new OrderItem()};
}
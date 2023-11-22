using Domain.Models;

namespace Application.ViewModels.Orders;

public class OrderDetailsViewModel
{
    public int OrderId { get; set; }
    public string Number { get; set; } = null!;
    public DateTime Date { get; set; }
    public Provider Provider { get; set; } = new();
    public List<OrderItem>? OrderItems { get; set; } = new() { new OrderItem() };
}
using System.ComponentModel;

namespace Domain.Models;

public class OrderItem
{
    [DisplayName("Item ID")]
    public int OrderItemId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Quantity { get; set; }

    public string Unit { get; set; } = null!;

    [DisplayName("Order ID")]
    public int OrderId { get; set; }
    public Order Order { get; set; } = new();
}
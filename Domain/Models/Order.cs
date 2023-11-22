using System.ComponentModel;

namespace Domain.Models;

public class Order
{
    [DisplayName("Order ID")]
    public int OrderId { get; set; }

    public string Number { get; set; } = null!;

    public DateTime Date { get; set; }

    [DisplayName("Provider")]
    public int ProviderId { get; set; }
    public Provider Provider { get; set; } = null!;

    public IList<OrderItem> OrderItems { get; set; } = null!;
}
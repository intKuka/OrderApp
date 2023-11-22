using Application.CQRS.Orders.Queries.GetOrderListView;
using Domain.Models;

namespace Application.ViewModels.Orders;

public class OrderListViewModel
{
    public Provider Provider { get; set; } = new();

    public List<Order> Orders { get; set; } = new();

    public OrderListFilter Filter { get; set; } = new();
}
// Filters:
// Order.Date
// Order.Number
// OrderItem.Name
// OrderItem.Unit
// Provider.Name
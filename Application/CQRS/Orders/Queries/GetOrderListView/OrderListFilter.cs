using Application.Common;
using Domain.Models;

namespace Application.CQRS.Orders.Queries.GetOrderListView;

public class OrderListFilter
{
    public DatePeriod? Date { get; set; } = new();
    public List<string> OrderNumbers { get; set; } = new();
    public List<string> ItemNames { get; set; } = new();
    public List<string> ItemUnits { get; set; } = new();
    public List<Provider> Providers { get; set; } = new();

    public List<string> SelectedOrderNumbers { get; set; } = new();
    public List<string> SelectedItemNames { get; set; } = new();
    public List<string> SelectedItemUnits { get; set; } = new();
    public List<int> SelectedProviderIds { get; set; } = new();
}
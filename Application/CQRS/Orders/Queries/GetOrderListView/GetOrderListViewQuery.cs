using Application.ViewModels.Orders;
using MediatR;

namespace Application.CQRS.Orders.Queries.GetOrderListView;

public record GetOrderListViewQuery(OrderListFilter Filter) : IRequest<OrderListViewModel>;
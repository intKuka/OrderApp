using Application.ViewModels.Orders;
using MediatR;

namespace Application.CQRS.Orders.Queries.GetOrderDetailsView;

public record GetOrderDetailsViewQuery(int Id) : IRequest<OrderDetailsViewModel>;
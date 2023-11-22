using Application.ViewModels.Orders;
using MediatR;

namespace Application.CQRS.Orders.Queries.GetOrderEditView;

public record GetOrderEditViewQuery(int Id) : IRequest<OrderEditViewModel>;
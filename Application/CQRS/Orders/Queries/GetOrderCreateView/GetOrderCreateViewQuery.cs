using Application.ViewModels.Orders;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Orders.Queries.GetOrderCreateView;

public record GetOrderCreateViewQuery : IRequest<OrderCreateViewModel>;
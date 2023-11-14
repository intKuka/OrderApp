using Domain.Models;
using MediatR;

namespace Application.Queries.GetOrderQuery;

public record GetOrderRequest(int Id) : IRequest<Order?>;
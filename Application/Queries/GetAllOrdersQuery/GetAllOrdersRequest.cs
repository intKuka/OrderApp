using Domain.Models;
using MediatR;

namespace Application.Queries.GetAllOrdersQuery;

public record GetAllOrdersRequest : IRequest<List<Order>>;
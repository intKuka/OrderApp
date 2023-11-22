using Domain.Models;
using MediatR;

namespace Application.CQRS.OrderItems.Queries.GetAllOrderItems
{
    public record GetAllOrderItemsQuery : IRequest<List<OrderItem>>;
}

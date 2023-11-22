using MediatR;

namespace Application.CQRS.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(int Id) : IRequest;
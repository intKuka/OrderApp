using Domain.Models;
using MediatR;

namespace Application.Commands.DeleteOrderCommand;

public class DeleteOrderCommand : Order, IRequest
{
}
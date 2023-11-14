using MediatR;

namespace Application.Commands.CreateOrderCommand;

public class CreateOrderCommand : IRequest
{
    public string Number { get; set; } = null!;
    public DateTimeOffset Date { get; set; }
    public int ProviderId { get; set; }
}
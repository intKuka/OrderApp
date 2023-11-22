using Domain.Models;

namespace Domain.Abstractions;

public interface IOrder
{
    int OrderId { get; set; }
    string Number { get; set; }
    DateTime Date { get; set; }
    int ProviderId { get; set; }
}
using Application.CQRS;
using Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator(IApplicationDbContext context)
    {
        RuleFor(x => x)
            .MustAsync(async (x, token) =>
                await context.Orders.AnyAsync(
                    order => x.OrderId != order.OrderId && order.Number == x.Number && order.ProviderId == x.ProviderId,
                    token) == false)
            .WithMessage("Selected provider already has an order with this number");

        RuleForEach(x => x.OrderItems)
            .Must((x, i) => i.Name != x.Number)
            .WithMessage("Name must not be equal order number");
    }
}

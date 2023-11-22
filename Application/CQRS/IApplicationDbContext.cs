using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS;

public interface IApplicationDbContext
{
    DbSet<Order> Orders { get; }
    DbSet<OrderItem> OrderItems { get; }
    DbSet<Provider> Providers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
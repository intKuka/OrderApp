using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application;

public interface IApplicationDbContext
{
    DbSet<Order> Orders { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
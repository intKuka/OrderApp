using Application;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) =>
        Database.EnsureCreated();

    public DbSet<Order> Orders => Set<Order>();
}
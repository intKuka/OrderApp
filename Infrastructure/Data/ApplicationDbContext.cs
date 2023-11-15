using Application;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Provider> Providers => Set<Provider>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(OrderConfigure);

        modelBuilder.Entity<OrderItem>(OrderItemConfigure);

        modelBuilder.Entity<Provider>(ProviderConfigure);
    }

    // Order configuration
    private static void OrderConfigure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.Number).HasColumnType("nvarchar");
        builder.Property(p => p.Date).HasColumnType("datetime2(7)");
    }

    // OrderItem configuration
    private static void OrderItemConfigure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(p => p.Name).HasColumnType("nvarchar");
        builder.Property(p => p.Quantity).HasPrecision(18, 3);
        builder.Property(p => p.Unit).HasColumnType("nvarchar");
    }

    // Provider configuration
    private static void ProviderConfigure(EntityTypeBuilder<Provider> builder)
    {
        builder.Property(p => p.Name).HasColumnType("nvarchar");
    }
}
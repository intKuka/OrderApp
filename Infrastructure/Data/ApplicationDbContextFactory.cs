using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        // TODO: read connection string from appsettings.json
        optionsBuilder.UseSqlite("DataSource=orderapp.db");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
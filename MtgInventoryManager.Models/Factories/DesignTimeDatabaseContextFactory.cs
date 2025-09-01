using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MtgInventoryManager.Models.Persistence;

namespace MtgInventoryManager.Models.Factories;

public class DesignTimeDatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
{
    public DatabaseContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<DatabaseContext> builder = new();
        builder.UseNpgsql("");

        return new DatabaseContext(builder.Options, false);
    }
}
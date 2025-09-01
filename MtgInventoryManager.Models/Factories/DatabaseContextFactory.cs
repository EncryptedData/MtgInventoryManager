using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MtgInventoryManager.Models.Abstractions;
using MtgInventoryManager.Models.Configuration;
using MtgInventoryManager.Models.Persistence;

namespace MtgInventoryManager.Models.Factories;

public class DatabaseContextFactory : IDatabaseContextFactory
{
    private readonly IOptions<ConnectionStringsConfig> _connectionStringOptions;

    public DatabaseContextFactory(IOptions<ConnectionStringsConfig> connectionStringOptions)
    {
        _connectionStringOptions = connectionStringOptions;
    }
    
    public IDatabaseContext Create(bool isReadOnly = false)
    {
        return new DatabaseContext(BuildOptions(), isReadOnly);
    }

    private DbContextOptions<DatabaseContext> BuildOptions()
    {
        DbContextOptionsBuilder<DatabaseContext> builder = new();
        builder.UseNpgsql(_connectionStringOptions.Value.Database);

        return builder.Options;
    }
}
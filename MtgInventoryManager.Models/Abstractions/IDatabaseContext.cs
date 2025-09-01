using Microsoft.EntityFrameworkCore;
using MtgInventoryManager.Models.Persistence;

namespace MtgInventoryManager.Models.Abstractions;

public interface IDatabaseContext : IAsyncDisposable
{
    bool IsReadOnly { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    DbSet<Card> Cards { get; set; }
    
    DbSet<CardSet> CardSets { get; set; }
    
    DbSet<CardSubType> CardSubTypes { get; set; }
    
    DbSet<CardType> CardTypes { get; set; }
    
    DbSet<Inventory> Inventories { get; set; }
    
    DbSet<InventoryItem> InventoryItems { get; set; }
    
    DbSet<User> Users { get; set; }
}
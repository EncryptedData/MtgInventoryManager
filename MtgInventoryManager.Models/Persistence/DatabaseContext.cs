using Microsoft.EntityFrameworkCore;
using MtgInventoryManager.Models.Abstractions;

namespace MtgInventoryManager.Models.Persistence;

public class DatabaseContext : DbContext, IDatabaseContext
{
    
    internal DatabaseContext(DbContextOptions<DatabaseContext> options, bool isReadOnly) :
        base(options)
    {
        IsReadOnly = isReadOnly;
    }

    public bool IsReadOnly { get; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        if (IsReadOnly)
        {
            throw new InvalidOperationException("Cannot persist read only DatabaseContext");
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CardType>()
            .HasData([
                new CardType { Id = "Creature" },
                new CardType { Id = "Artifact" },
                new CardType { Id = "Instant" },
                new CardType { Id = "Sorcery" },
                new CardType { Id = "Enchantment" },
                new CardType { Id = "Land" },
                new CardType { Id = "Planeswalker" }
            ]);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Card> Cards { get; set; }
    
    public DbSet<CardSet> CardSets { get; set; }

    public DbSet<CardSubType> CardSubTypes { get; set; }

    public DbSet<CardType> CardTypes { get; set; }

    public DbSet<Inventory> Inventories { get; set; }

    public DbSet<InventoryItem> InventoryItems { get; set; }
    
    public DbSet<User> Users { get; set; }
}
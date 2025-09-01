using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MtgInventoryManager.Models.Abstractions;

namespace MtgInventoryManager.Models.Persistence;

public class Inventory : IPersistEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public string DisplayName { get; set; }
    
    public User User;
    
    public ICollection<InventoryItem> Items { get; set; }
}
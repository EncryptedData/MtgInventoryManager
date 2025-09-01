using System.ComponentModel.DataAnnotations;
using MtgInventoryManager.Models.Abstractions;

namespace MtgInventoryManager.Models.Persistence;

public class User : IPersistEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public string DisplayName { get; set; }
    
    public ICollection<Inventory> Inventories { get; set; }
}
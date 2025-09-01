using System.ComponentModel.DataAnnotations;
using MtgInventoryManager.Models.Abstractions;

namespace MtgInventoryManager.Models.Persistence;

public class InventoryItem : IPersistEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public Inventory Inventory { get; set; }
    
    public CardGrade CardGrade { get; set; }
    
    public uint Amount { get; set; }
    
    public Card Card { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace MtgInventoryManager.Models.Persistence;

public class CardType
{
    [Key]
    public string Id { get; set; }
}
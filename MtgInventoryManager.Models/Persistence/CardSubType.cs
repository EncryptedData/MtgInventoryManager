using System.ComponentModel.DataAnnotations;

namespace MtgInventoryManager.Models.Persistence;

public class CardSubType
{
    [Key]
    public string Name { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace MtgInventoryManager.Models.Transfer;

public class CardSetDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string SetKey { get; set; }

    public DateTime ReleaseDate { get; set; }
    
    [Required]
    public string DisplayName { get; set; }
    
    [Range(1,uint.MaxValue)]
    public uint NumberOfCardsInSet { get; set; }

    // public ICollection<Card> Cards { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using MtgInventoryManager.Models.Abstractions;

namespace MtgInventoryManager.Models.Persistence;

[Index(nameof(SetKey), nameof(ReleaseDate), nameof(DisplayName))]
[Table("CardSets")]
public class CardSet : IPersistEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public string SetKey { get; set; }

    public DateTime ReleaseDate { get; set; }
    
    public string DisplayName { get; set; }
    
    public uint NumberOfCardsInSet { get; set; }

    public ICollection<Card> Cards { get; set; }
}
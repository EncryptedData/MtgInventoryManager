using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using MtgInventoryManager.Models.Abstractions;

namespace MtgInventoryManager.Models.Persistence;

[Index(nameof(SetNumber), nameof(Name))]
public class Card : IPersistEntity
{
    [Key]
    public Guid Id { get; set; }
    
    public CardSet CardSet { get; set; }

    public uint SetNumber { get; set; }
    
    public ICollection<CardType> CardTypes { get; set; }
    
    public ICollection<CardSubType>? SubTypes { get; set; }
    
    public string Name { get; set; }
    
    public string RulesText { get; set; }
    
    public string FlavorText { get; set; }
    
    public string ManaCost { get; set; }
    
    public string ArtistAttribution { get; set; }
}
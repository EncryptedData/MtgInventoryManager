using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtgInventoryManager.Models.Abstractions;
using MtgInventoryManager.Models.Persistence;
using MtgInventoryManager.Models.Transfer;

namespace MtgInventoryManager.Controllers.ApiV1;

[ApiController]
[Route("/api/1/cardset")]
public class CardSetController : ControllerBase
{
    private readonly IDatabaseContextFactory _dbFactory;

    public CardSetController(IDatabaseContextFactory dbFactory)
    {
        _dbFactory = dbFactory;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        await using var db = _dbFactory.Create();
        return Ok(await db.CardSets.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CardSetDto cardSetDto)
    {
        CardSet cardSet = new CardSet()
        {
            Id = cardSetDto.Id,
            SetKey = cardSetDto.SetKey,
            DisplayName = cardSetDto.DisplayName,
            NumberOfCardsInSet = cardSetDto.NumberOfCardsInSet,
            ReleaseDate = cardSetDto.ReleaseDate,
        };
        
        await using var db = _dbFactory.Create();
        if (await db.CardSets.AnyAsync(c => c.SetKey == cardSetDto.SetKey))
        {
            return Conflict();
        }
        await db.CardSets.AddAsync(cardSet);
        await db.SaveChangesAsync();
        return Created();
    }
}
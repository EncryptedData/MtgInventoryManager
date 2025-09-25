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

    [HttpGet("{setKey}")]
    public async Task<IActionResult> GetByIdAsync(string setKey)
    {
        await using var db = _dbFactory.Create();
        var cardSet = await db.CardSets.FirstOrDefaultAsync(x => x.SetKey == setKey);
        
        if (cardSet is null)
        {
            return NotFound();
        }
        
        CardSetDto dto = new()
        {
            Id = cardSet.Id,
            SetKey = cardSet.SetKey,
            ReleaseDate = cardSet.ReleaseDate,
            DisplayName = cardSet.DisplayName,
            NumberOfCardsInSet = cardSet.NumberOfCardsInSet,
        };
        
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CardSetDto cardSetDto)
    {
        var cardSet = new CardSet()
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
    
    [HttpPut("{setKey}")]
    public async Task<IActionResult> UpdateCardSet(string setKey, CardSetDto cardSetDto)
    {
        if (setKey != cardSetDto.SetKey)
        {
            return BadRequest();
        }
        
        await using var db = _dbFactory.Create();
        var cardSet = await db.CardSets.FirstOrDefaultAsync(x => x.SetKey == cardSetDto.SetKey);

        if (cardSet is null)
        {
            return NotFound();
        }
        
        cardSet.DisplayName = cardSetDto.DisplayName;
        cardSet.NumberOfCardsInSet = cardSetDto.NumberOfCardsInSet;
        cardSet.ReleaseDate = cardSetDto.ReleaseDate;

        db.CardSets.Update(cardSet);
        await db.SaveChangesAsync();
        return Ok();
    }
    
    // [HttpDelete("{setKey}")]
    // Delete Function Goes Here
}
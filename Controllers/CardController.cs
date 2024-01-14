using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.DTOs;
using CourseworkNoSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkNoSQL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : Controller
{
    private readonly ICardRepository _repository;

    public CardController(ICardRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ICollection<Card>> Get(CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken: cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Card card, CancellationToken cancellationToken)
    {
        await _repository.InsertAsync(card, cancellationToken: cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = card.Number }, card);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Card updatedCard, CancellationToken cancellationToken)
    {
        var card = await _repository.SelectByIdAsync(id, cancellationToken: cancellationToken);
        if (card is null)
        {
            return NotFound();
        }

        updatedCard.Number = card.Number;
        await _repository.UpdateAsync(updatedCard, cancellationToken);
        return NoContent();
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var card = await _repository.SelectByIdAsync(id, cancellationToken);
        if (card is null)
        {
            return NotFound();
        }
        await _repository.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
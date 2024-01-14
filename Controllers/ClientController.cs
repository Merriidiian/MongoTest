using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.DTOs;
using CourseworkNoSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkNoSQL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : Controller
{
    private readonly IClientRepository _repository;

    public ClientController(IClientRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ICollection<Client>> Get(CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken: cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> Post(ClientDTO client, CancellationToken cancellationToken)
    {
        var newClient = new Client
        {
            Id = new Guid(),
            Name = client.Name,
            Passport = client.Passport,
            Patronymic = client.Patronymic,
            Surname = client.Surname
        };
        await _repository.InsertAsync(newClient, cancellationToken: cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newClient.Id }, newClient);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid id, Client updatedClient, CancellationToken cancellationToken)
    {
        var client = await _repository.SelectByIdAsync(id, cancellationToken: cancellationToken);
        if (client is null)
        {
            return NotFound();
        }

        updatedClient.Id = client.Id;
        await _repository.UpdateAsync(updatedClient, cancellationToken);
        return NoContent();
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var client = await _repository.SelectByIdAsync(id, cancellationToken);
        if (client is null)
        {
            return NotFound();
        }
        await _repository.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
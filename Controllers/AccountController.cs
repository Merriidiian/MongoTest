using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.DTOs;
using CourseworkNoSQL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseworkNoSQL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly IAccountRepository _repository;

    public AccountController(IAccountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ICollection<Account>> Get(CancellationToken cancellationToken)
    {
        return await _repository.SelectAllAsync(cancellationToken: cancellationToken);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AccountDTO account, CancellationToken cancellationToken)
    {
        var newAccount = new Account
        {
            Id = new Guid(),
            Inn = account.Inn,
            ClientId = account.ClientId
        };
        await _repository.InsertAsync(newAccount, cancellationToken: cancellationToken);
        return CreatedAtAction(nameof(Get), new { id = newAccount.Id }, newAccount);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(Guid id, Account updatedAccount, CancellationToken cancellationToken)
    {
        var account = await _repository.SelectByIdAsync(id, cancellationToken: cancellationToken);
        if (account is null)
        {
            return NotFound();
        }

        updatedAccount.Id = account.Id;
        await _repository.UpdateAsync(updatedAccount, cancellationToken);
        return NoContent();
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var account = await _repository.SelectByIdAsync(id, cancellationToken);
        if (account is null)
        {
            return NotFound();
        }
        await _repository.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
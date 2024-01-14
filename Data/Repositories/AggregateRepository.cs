using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CourseworkNoSQL.Data.Repositories;

public class AggregateRepository : IAggregateRepository
{
    private readonly IClientRepository _clientRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ICardRepository _cardRepository;

    public AggregateRepository(IClientRepository clientRepository, IAccountRepository accountRepository, ICardRepository cardRepository)
    {
        _clientRepository = clientRepository;
        _accountRepository = accountRepository;
        _cardRepository = cardRepository;
    }

    public async Task<Aggregate> AggregateLinqAsync(Guid idClient, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.SelectByIdAsync(idClient, cancellationToken);
        var listAccounts = _accountRepository.SelectAllAsync(cancellationToken).Result.Where(a => a.ClientId == client.Id).ToList();
        var listCards = new List<Card>();
        foreach (var account in listAccounts)
        {
            listCards.AddRange(_cardRepository.SelectAllAsync(cancellationToken).Result.Where(c => c.AccountId == account.Id));
        }

        var aggregate = new Aggregate
        {
            Client = client,
            Accounts = listAccounts,
            Cards = listCards
        };
        return aggregate;
    }
}
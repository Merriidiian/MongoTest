using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.Models;
using MongoDB.Driver;

namespace CourseworkNoSQL.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IMongoCollection<Account> _collection;

    public AccountRepository(BankContext bankContext)
    {
        _collection = bankContext._accountCollection;
    }
    public async Task<Account?> SelectByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result =  await _collection.FindAsync(x => x.Id == id, cancellationToken: cancellationToken);
        return await result.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<Account>> SelectAllAsync(CancellationToken cancellationToken)
    {
        var result =  await _collection.FindAsync(_ => true, cancellationToken: cancellationToken);
        return await result.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task InsertAsync(Account obj, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(obj, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(Account obj, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(x => x.Id == obj.Id, obj, cancellationToken: cancellationToken);
    }
}
using CourseworkNoSQL.Data.Repositories.Interfaces;
using CourseworkNoSQL.Models;
using MongoDB.Driver;

namespace CourseworkNoSQL.Data.Repositories;

public class CardRepository : ICardRepository
{
    private readonly IMongoCollection<Card> _collection;

    public CardRepository(BankContext bankContext)
    {
        _collection = bankContext._cardCollection;
    }
    public async Task<Card> SelectByIdAsync(string id, CancellationToken cancellationToken)
    {
        var result =  await _collection.FindAsync(x => x.Number == id, cancellationToken: cancellationToken);
        return await result.FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
    public async Task<ICollection<Card>> SelectAllAsync(CancellationToken cancellationToken)
    {
        var result =  await _collection.FindAsync(_ => true, cancellationToken: cancellationToken);
        return await result.ToListAsync(cancellationToken: cancellationToken);    }

    public async Task InsertAsync(Card card, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(card, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(x => x.Number == id, cancellationToken: cancellationToken);
    }
    

    public async Task UpdateAsync(Card obj, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(x => x.Number == obj.Number, obj, cancellationToken: cancellationToken);
    }
}
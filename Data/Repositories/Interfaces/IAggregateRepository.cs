using CourseworkNoSQL.Models;
using MongoDB.Bson;

namespace CourseworkNoSQL.Data.Repositories.Interfaces;

public interface IAggregateRepository
{
    public Task<Aggregate> AggregateLinqAsync(Guid idClient, CancellationToken cancellationToken);
    public Task<BsonDocument> GetLookup(Guid idClient);
}
using CourseworkNoSQL.Models;

namespace CourseworkNoSQL.Data.Repositories.Interfaces;

public interface IAggregateRepository
{
    public Task<Aggregate> AggregateLinq(Guid idClient, CancellationToken cancellationToken);
}
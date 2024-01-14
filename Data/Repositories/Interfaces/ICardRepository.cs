using CourseworkNoSQL.Models;

namespace CourseworkNoSQL.Data.Repositories.Interfaces;

public interface ICardRepository : ICrudMethods<Card>
{

    Task ICrudMethods<Card>.DeleteAsync(Guid id, CancellationToken cancellationToken) => null;
    new Task DeleteAsync(string id, CancellationToken cancellationToken);
    
    Task<Card> ICrudMethods<Card>.SelectByIdAsync(Guid id, CancellationToken cancellationToken) => null;
    new Task<Card> SelectByIdAsync(string id, CancellationToken cancellationToken);
}
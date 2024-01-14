namespace CourseworkNoSQL.Data.Repositories.Interfaces;

public interface ICrudMethods<T>
{
    Task<T?> SelectByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ICollection<T>> SelectAllAsync(CancellationToken cancellationToken);
    Task InsertAsync(T obj, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task UpdateAsync(T obj, CancellationToken cancellationToken);
}
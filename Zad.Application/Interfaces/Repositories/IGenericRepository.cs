using Zad.Domain.Common;

namespace Zad.Application.Interfaces.Repositories;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(int id);
    Task<IReadOnlyList<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    Task DeleteAsync(int id);
    Task<int> CountAsync();
}

using Microsoft.EntityFrameworkCore;
using Zad.Domain.Common;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ZadDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    public GenericRepository(ZadDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);
        if (entity is null)
        {
            return;
        }

        DbSet.Remove(entity);
    }

    public async Task<int> CountAsync()
    {
        return await DbSet.CountAsync();
    }
}

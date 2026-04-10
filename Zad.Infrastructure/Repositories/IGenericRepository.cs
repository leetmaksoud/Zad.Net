using Zad.Domain.Common;

namespace Zad.Infrastructure.Repositories;

public interface IGenericRepository<TEntity> : Zad.Application.Interfaces.Repositories.IGenericRepository<TEntity> where TEntity : BaseEntity
{
}

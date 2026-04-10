using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface ICategoryRepository : Zad.Application.Interfaces.Repositories.ICategoryRepository, IGenericRepository<Category>
{
}

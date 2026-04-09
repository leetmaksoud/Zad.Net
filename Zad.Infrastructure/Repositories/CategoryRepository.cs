using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ZadDbContext context) : base(context)
    {
    }
}

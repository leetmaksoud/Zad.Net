using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdWithRoles(int id);
}

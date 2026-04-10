using Zad.Domain.Entities;

namespace Zad.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByEmailWithRolesAsync(string email);
    Task<User?> GetByIdWithRolesAsync(int id);
}

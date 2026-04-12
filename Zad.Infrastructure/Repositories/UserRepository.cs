using Microsoft.EntityFrameworkCore;
using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ZadDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Users
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByEmailWithRolesAsync(string email)
    {
        return await Context.Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<User?> GetByIdWithRolesAsync(int id)
    {
        return await Context.Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}

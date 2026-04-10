using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IUserRepository : Zad.Application.Interfaces.Repositories.IUserRepository, IGenericRepository<User>
{
}

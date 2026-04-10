using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface ICitationRepository : Zad.Application.Interfaces.Repositories.ICitationRepository, IGenericRepository<Citation>
{
}

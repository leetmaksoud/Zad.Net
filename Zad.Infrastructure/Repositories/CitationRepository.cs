using Zad.Domain.Entities;
using Zad.Infrastructure.Persistence;

namespace Zad.Infrastructure.Repositories;

public class CitationRepository : GenericRepository<Citation>, ICitationRepository
{
    public CitationRepository(ZadDbContext context) : base(context)
    {
    }
}

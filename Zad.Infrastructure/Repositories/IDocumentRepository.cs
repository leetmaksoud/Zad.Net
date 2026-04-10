using Zad.Domain.Entities;

namespace Zad.Infrastructure.Repositories;

public interface IDocumentRepository : Zad.Application.Interfaces.Repositories.IDocumentRepository, IGenericRepository<Document>
{
}

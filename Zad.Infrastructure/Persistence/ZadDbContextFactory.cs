using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Zad.Infrastructure.Persistence;

public class ZadDbContextFactory : IDesignTimeDbContextFactory<ZadDbContext>
{
    public ZadDbContext CreateDbContext(string[] args)
    {
        var connectionString =
            Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
            ?? "Server=(localdb)\\mssqllocaldb;Database=ZadDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

        var optionsBuilder = new DbContextOptionsBuilder<ZadDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ZadDbContext(optionsBuilder.Options);
    }
}

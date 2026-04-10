using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zad.Infrastructure.External;
using Zad.Infrastructure.Persistence;
using Zad.Infrastructure.Repositories;
using Zad.Infrastructure.UnitOfWork;

namespace Zad.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");

        services.AddDbContext<ZadDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IChatSessionRepository, ChatSessionRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<ICitationRepository, CitationRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IRequestLogRepository, RequestLogRepository>();
        services.AddScoped<IUnitOfWork, Zad.Infrastructure.UnitOfWork.UnitOfWork>();
        services.AddScoped<Zad.Application.Interfaces.IUnitOfWork>(sp => sp.GetRequiredService<IUnitOfWork>());

        services.Configure<AiClientOptions>(configuration.GetSection("AiService"));
        services.AddHttpClient<Zad.Application.Interfaces.IAiClient, AiClient>((serviceProvider, client) =>
        {
            var options = serviceProvider.GetRequiredService<Microsoft.Extensions.Options.IOptions<AiClientOptions>>().Value;

            if (!string.IsNullOrWhiteSpace(options.BaseUrl))
            {
                client.BaseAddress = new Uri(options.BaseUrl);
            }

            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds > 0 ? options.TimeoutSeconds : 30);
        });

        services.AddScoped<IAiClient>(sp => (IAiClient)sp.GetRequiredService<Zad.Application.Interfaces.IAiClient>());

        return services;
    }
}

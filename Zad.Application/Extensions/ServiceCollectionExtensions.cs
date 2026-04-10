using Microsoft.Extensions.DependencyInjection;
using Zad.Application.Interfaces;
using Zad.Application.Interfaces.Repositories;
using Zad.Application.Services;

namespace Zad.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceCollectionExtensions).Assembly);

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IRequestLogService, RequestLogService>();

        services.AddScoped<IUserRepository>(sp => sp.GetRequiredService<IUnitOfWork>().Users);
        services.AddScoped<IChatSessionRepository>(sp => sp.GetRequiredService<IUnitOfWork>().ChatSessions);
        services.AddScoped<IMessageRepository>(sp => sp.GetRequiredService<IUnitOfWork>().Messages);
        services.AddScoped<ICitationRepository>(sp => sp.GetRequiredService<IUnitOfWork>().Citations);
        services.AddScoped<IDocumentRepository>(sp => sp.GetRequiredService<IUnitOfWork>().Documents);
        services.AddScoped<ICategoryRepository>(sp => sp.GetRequiredService<IUnitOfWork>().Categories);
        services.AddScoped<IRequestLogRepository>(sp => sp.GetRequiredService<IUnitOfWork>().RequestLogs);

        RegisterValidators(services);

        return services;
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        const string validatorInterfaceName = "FluentValidation.IValidator`1";
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        var validators = assembly
            .GetTypes()
            .Where(type => !type.IsAbstract && !type.IsInterface)
            .SelectMany(type => type
                .GetInterfaces()
                .Where(iface => iface.IsGenericType && iface.GetGenericTypeDefinition().FullName == validatorInterfaceName)
                .Select(iface => new { ServiceType = iface, ImplementationType = type }))
            .ToList();

        foreach (var validator in validators)
        {
            services.AddScoped(validator.ServiceType, validator.ImplementationType);
        }
    }
}

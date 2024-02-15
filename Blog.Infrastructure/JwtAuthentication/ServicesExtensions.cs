using Blog.Infrastructure.JwtAuthentication.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure.JwtAuthentication;

public static class ServicesExtensions
{
    public static IServiceCollection AddJwtAuthenticationService(this IServiceCollection serviceCollection, IConfigurationSection section)
    {
        serviceCollection.AddSingleton(new JwtTokenFactory(section));
        serviceCollection.AddSingleton<IAuthenticationService, AuthenticationService>();
        return serviceCollection;
    }
}
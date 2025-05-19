using Microsoft.Extensions.DependencyInjection;

namespace RestApi.Client;

public static class ServiceProviderExtension
{
    public static IServiceCollection RegisterClients(this IServiceCollection container)
    {
        container.AddHttpClient();
        container.AddScoped<IOrderClient, OrderClient>();
        container.AddScoped<ILawnmowerClient, LawnmowerClient>();
        return container;
    }
}

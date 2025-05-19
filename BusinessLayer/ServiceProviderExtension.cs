using BusinessLayer;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtension
{
    public static IServiceCollection RegisterServices(this IServiceCollection container)
    {
        container.AddScoped<ILawnmowerService, LawnmowerService>();
        container.AddScoped<IOrderService, OrderService>();

        return container;
    }
}
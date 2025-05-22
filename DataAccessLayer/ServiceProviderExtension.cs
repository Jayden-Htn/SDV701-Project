using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceProviderExtension
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection container)
    {
        container.AddScoped<IUnitOfWork, UnitOfWork>();
        container.AddScoped<ILawnmowerRepository, LawnmowerRepository>();
        container.AddScoped<IOrderRepository, OrderRepository>();

        return container;
    }

    public static IServiceCollection RegisterDbContext(this IServiceCollection container, string connectionString)
    { 
            container.AddDbContext<ModelContext>(options => options.UseLazyLoadingProxies()
                                                                   .UseSqlServer(connectionString));

        return container;
    }
}
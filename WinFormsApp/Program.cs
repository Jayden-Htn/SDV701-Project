using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Client;
using WinFormsApp.Presenters;
using WinFormsApp.Views;

namespace WinFormsApp;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Set up DI config
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();

        var apiConfiguration = configuration.GetSection("ApiConfiguration").Get<ApiConfiguration>();

        var services = new ServiceCollection();
        services.AddSingleton<IApiConfiguration>(apiConfiguration);
        services.RegisterClients();
        services.AddSingleton<ProductsForm>();
        services.AddSingleton<ProductForm>();
        services.AddSingleton<OrdersForm>();
        services.AddSingleton<IProductsView>(sp => sp.GetRequiredService<ProductsForm>());
        services.AddSingleton<IProductView>(sp => sp.GetRequiredService<ProductForm>());
        services.AddSingleton<IOrdersView>(sp => sp.GetRequiredService<OrdersForm>());
        services.AddSingleton<ProductsPresenter>();
        services.AddSingleton<ProductPresenter>();
        services.AddSingleton<OrdersPresenter>();

        var provider = services.BuildServiceProvider();
        ApplicationConfiguration.Initialize();

        // Start presenters and run
        var mainView = provider.GetRequiredService<IProductsView>();

        _ = provider.GetRequiredService<ProductsPresenter>();
        _ = provider.GetRequiredService<ProductPresenter>();
        _ = provider.GetRequiredService<OrdersPresenter>();

        Application.Run((Form)mainView);
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestApi.Client;
using WinFormsApp.Presenters;
using WinFormsApp.Views;
using Microsoft.Extensions.Configuration.Json;

namespace WinFormsApp;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        var configuration = builder.Build();

        var apiConfiguration = configuration.GetSection("ApiConfiguration").Get<ApiConfiguration>();

        var services = new ServiceCollection();
        services.AddSingleton<IApiConfiguration>(apiConfiguration);
        services.RegisterClients();
        services.AddSingleton<ProductsForm>();
        services.AddTransient<ProductForm>();
        services.AddTransient<OrdersForm>();
        services.AddSingleton<IProductsView>(sp => (IProductsView)sp.GetRequiredService<ProductsForm>());
        services.AddSingleton<IProductView>(sp => (IProductView)sp.GetRequiredService<ProductForm>());
        services.AddSingleton<IOrdersView>(sp => (IOrdersView)sp.GetRequiredService<OrdersForm>());
        services.AddSingleton<ProductsPresenter>();
        services.AddSingleton<ProductPresenter>();
        services.AddSingleton<OrdersPresenter>();

        var provider = services.BuildServiceProvider();

        ApplicationConfiguration.Initialize();

        var mainView = provider.GetRequiredService<IProductsView>();

        Application.Run((Form)mainView);
    }
}
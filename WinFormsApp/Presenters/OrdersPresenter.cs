using RestApi.Client;
using WinFormsApp.Models;
using WinFormsApp.Views;

namespace WinFormsApp.Presenters;

public class OrdersPresenter
{
    readonly IOrdersView _view;
    readonly IOrderClient _orderClient;
    readonly IServiceProvider _services;

    public IOrdersView View => _view;

    public OrdersPresenter(IOrdersView view, IOrderClient orderClient, IServiceProvider services)
    {
        _view = view;
        _orderClient = orderClient;
        _services = services;

        _view.StatusChangeRequested += OnStatusChange;
        _view.DeleteRequested += OnDelete;
        _view.CloseRequested += OnCloseRequested;
        _view.LoadRequested += OnLoadRequested;
    }

    private async Task LoadOrdersAsync()
    {
        var orders = await _orderClient.ListAsync();

        var model = new OrdersDataModel();
        model.Orders = orders.ToList();
        model.TotalValue = model.Orders.Sum(i => i.ItemPrice);

        View.Model = model;
    }

    private async void OnStatusChange(object sender, int id)
    {
        // Can change order status
    }

    private async void OnDelete(object sender, int id)
    {
        await _orderClient.DeleteAsync(id);

        await LoadOrdersAsync();
    }

    private void OnCloseRequested(object? sender, EventArgs e)
    {
        View.Close();
    }

    private async void OnLoadRequested(object? sender, EventArgs e)
    {
        await LoadOrdersAsync();
    }
}

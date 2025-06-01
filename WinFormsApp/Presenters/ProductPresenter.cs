using Models;
using RestApi.Client;
using WinFormsApp.Models;
using WinFormsApp.Views;

namespace WinFormsApp.Presenters;

public class ProductPresenter
{
    readonly IProductView _view;
    readonly ILawnmowerClient _lawnmowerClient;
    readonly IServiceProvider _services;

    IList<BrandModel> _brands;

    public IProductView View => _view;

    public ProductPresenter(IProductView view, ILawnmowerClient lawnmowerClient, IServiceProvider services)
    {
        _view = view;
        _lawnmowerClient = lawnmowerClient;
        _services = services;

        _view.SaveRequested += OnSave;
        _view.CloseRequested += OnCloseRequested;
        _view.LoadRequested += OnLoadRequested;
    }

    private async Task LoadLawnmowerAsync()
    {
        var oldModel = _view.Model.Lawnmower;

        ProductDataModel model = new();
        if (oldModel.Id != 0)
        {
            model.Lawnmower = await _lawnmowerClient.GetAsync(oldModel.Id, oldModel.Type);
        }
        else
        {
            model.Lawnmower = oldModel;
        }

        if (_brands == null)
        {
            _brands = await _lawnmowerClient.ListBrandsAsync();
        }

        model.Brands = _brands.ToList();

        View.Model = model;
    }

    private async void OnSave(object sender, ILawnmowerModel model)
    {
        if (model.Id == 0)
        {
            // Create
            await _lawnmowerClient.AddAsync(model); 
        }
        else
        {
            // Update
             await _lawnmowerClient.UpdateAsync(model);
        }
        View.Close();
    }

    private void OnCloseRequested(object? sender, EventArgs e)
    {
        View.Close();
    }

    private async void OnLoadRequested(object? sender, EventArgs e)
    {
        await LoadLawnmowerAsync();
    }
}

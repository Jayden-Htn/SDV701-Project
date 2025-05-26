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

        _view.AddRequested += OnAdd;
        _view.EditRequested += OnEdit;
        _view.DeleteRequested += OnDelete;
        _view.CloseRequested += OnCloseRequested;
        _view.LoadRequested += OnLoadRequested;
    }

    private async Task LoadLawnmowerAsync()
    {
        var oldModel = _view.Model.Lawnmower;
        var lawnmower = await _lawnmowerClient.GetAsync(oldModel.Id, oldModel.Type);

        if (_brands == null)
        {
            _brands = await _lawnmowerClient.ListBrandsAsync();
        }

        var model = new ProductDataModel();
        model.Lawnmower = lawnmower;
        model.Brands = _brands.ToList();

        View.Model = model;
    }

    private async void OnAdd(object sender, EventArgs e)
    {
        //var form = (ProductForm)_services.GetService(typeof(ProductForm));
        //form.SetDetails(new LawnmowerModel());

        //if (form.ShowDialog() == DialogResult.OK)
        //{
        //    await _lawnmowerClient.AddAsync(form.GetDetails());
        //    await LoadLawnmowerAsync();
        //}
    }

    private async void OnEdit(object sender, int id)
    {
        //var lawnmower = await _lawnmowerClient.GetAsync(id);

        //var form = (ProductForm)_services.GetService(typeof(ProductForm));
        //form.SetDetails(lawnmower);

        //if (form.ShowDialog() == DialogResult.OK)
        //{
        //    await _lawnmowerClient.AddAsync(form.GetDetails());
        //    await LoadLawnmowerAsync();
        //}
    }

    private async void OnDelete(object sender, int id)
    {
        await _lawnmowerClient.DeleteAsync(id);
        await LoadLawnmowerAsync();
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

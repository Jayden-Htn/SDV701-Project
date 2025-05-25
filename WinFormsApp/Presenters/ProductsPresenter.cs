using Microsoft.Extensions.DependencyInjection;
using Models;
using RestApi.Client;
using WinFormsApp.Models;
using WinFormsApp.Views;

namespace WinFormsApp.Presenters
{
    public class ProductsPresenter
    {
        readonly IProductsView _view;
        readonly ILawnmowerClient _lawnmowerClient;
        readonly IOrderClient _orderClient;
        readonly IServiceProvider _services;

        private int _currentBrandFilterId = 0;
        IList<BrandModel> _brands;

        public ProductsPresenter(IProductsView view, ILawnmowerClient lawnmowerClient, IOrderClient orderClient, IServiceProvider services)
        {
            _view = view;
            _lawnmowerClient = lawnmowerClient;
            _orderClient = orderClient;
            _services = services;

            _view.AddRequested += OnAdd;
            _view.EditRequested += OnEdit;
            _view.DeleteRequested += OnDelete;
            _view.QuitRequested += OnQuitRequested;
            _view.LoadRequested += OnLoadRequested;
            _view.FilterRequested += OnFilterRequested;
            _view.ViewOrders += OnViewOrders;
        }

        private async Task LoadDataAsync()
        {
            var lawnmowers = await _lawnmowerClient.ListAsync(_currentBrandFilterId);

            if (_brands == null)
            {
                _brands = await _lawnmowerClient.ListBrandsAsync();
            }
            

            var model = new ProductsDataModel();
            model.Lawnmowers = lawnmowers.ToList();
            model.Brands = _brands.ToList();
            model.CurrentBrandId = _currentBrandFilterId;

            _view.Model = model;
        }

        private async void OnAdd(object sender, EventArgs e)
        {
            var form = (ProductForm)_services.GetService(typeof(ProductForm));
            var data = new ProductDataModel();
            data.Lawnmower = new LawnmowerModel();
            form.Model = data;

            if (form.ShowDialog() == DialogResult.OK)
            {
                await _lawnmowerClient.AddAsync(form.GetData());
                await LoadDataAsync();
            }
        }

        private async void OnEdit(object sender, int id)
        {
            var form = (ProductForm)_services.GetService(typeof(ProductForm));
            var lawnmower = await _lawnmowerClient.GetAsync(id);

            var data = new ProductDataModel();
            data.Lawnmower = lawnmower;
            form.Model = data;

            if (form.ShowDialog() == DialogResult.OK)
            {
                await _lawnmowerClient.AddAsync(form.GetData());
                await LoadDataAsync();
            }
        }

        private async void OnDelete(object sender, int id)
        {
            await _lawnmowerClient.DeleteAsync(id);
            await LoadDataAsync();
        }

        private void OnQuitRequested(object? sender, EventArgs e)
        {
            _view.Close();
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void OnFilterRequested(object? sender, int brandId)
        {
            if (brandId != _currentBrandFilterId)
            {
                _currentBrandFilterId = brandId;
                LoadDataAsync();
            }
        }

        private async void OnViewOrders(object sender, EventArgs e)
        {
            var presenter = _services.GetRequiredService<OrdersPresenter>();
            var form = (OrdersForm)presenter.View;

            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadDataAsync();
            }
        }
    }
}

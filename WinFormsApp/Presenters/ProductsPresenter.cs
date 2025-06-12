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

        int _currentBrandFilterId = 0;
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

        private async void OnAdd(object sender, ILawnmowerModel model)
        {
            var form = (_services.GetRequiredService<ProductPresenter>()).View;

            var data = new ProductDataModel();
            data.Lawnmower = model;
            data.Brands = _brands;
            form.Model = data;

            if (form.ShowDialog() == DialogResult.OK)
            {
                Thread.Sleep(250); // Otherwise save hasn't finished and gets old data
                await LoadDataAsync();
            }
        }

        private async void OnEdit(object sender, ILawnmowerModel model)
        {
            var form = (_services.GetRequiredService<ProductPresenter>()).View;

            var lawnmower = await _lawnmowerClient.GetAsync(model.Id, model.Type);
            var data = new ProductDataModel();
            data.Lawnmower = lawnmower;
            data.Brands = _brands;
            form.Model = data;

            if (form.ShowDialog() == DialogResult.OK)
            {
                Thread.Sleep(200); // Otherwise save hasn't finished and gets old data
                await LoadDataAsync();
            }
        }

        private async void OnDelete(object sender, int id)
        {
            string msg = "Are you sure you want to delete this product?";
            if (MessageBox.Show(msg, "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                await _lawnmowerClient.DeleteAsync(id);
                await LoadDataAsync();
            }
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

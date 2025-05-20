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
        readonly IServiceProvider _services;

        public ProductsPresenter(IProductsView view, ILawnmowerClient lawnmowerClient, IServiceProvider services)
        {
            _view = view;
            _lawnmowerClient = lawnmowerClient;
            _services = services;

            _view.AddRequested += OnAdd;
            _view.EditRequested += OnEdit;
            _view.DeleteRequested += OnDelete;
            _view.QuitRequested += OnQuitRequested;
            _view.LoadRequested += OnLoadRequested;
        }

        private async Task LoadLawnmowersAsync()
        {
            var lawnmowers = await _lawnmowerClient.ListAsync();

            var model = new ProductsDataModel();
            model.Lawnmowers = lawnmowers.ToList();

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
                await LoadLawnmowersAsync();
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
                await LoadLawnmowersAsync();
            }
        }

        private async void OnDelete(object sender, int id)
        {
            await _lawnmowerClient.DeleteAsync(id);
            await LoadLawnmowersAsync();
        }

        private void OnQuitRequested(object? sender, EventArgs e)
        {
            _view.Close();
        }

        private async void OnLoadRequested(object? sender, EventArgs e)
        {
            await LoadLawnmowersAsync();
        }
    }
}

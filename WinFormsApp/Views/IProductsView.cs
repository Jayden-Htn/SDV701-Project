using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IProductsView
{
    ProductsDataModel Model { set; }

    event EventHandler AddRequested;
    event EventHandler<int> EditRequested;
    event EventHandler<int> DeleteRequested;
    event EventHandler QuitRequested;
    event EventHandler LoadRequested;
    event EventHandler<int> FilterRequested;

    void Close();
}

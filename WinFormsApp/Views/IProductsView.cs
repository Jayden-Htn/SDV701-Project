using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IProductsView
{
    ProductsDataModel Model { set; }

    event EventHandler AddRequested;
    event EventHandler<ILawnmowerModel> EditRequested;
    event EventHandler<int> DeleteRequested;
    event EventHandler QuitRequested;
    event EventHandler LoadRequested;
    event EventHandler<int> FilterRequested;
    event EventHandler ViewOrders;

    void Close();
}

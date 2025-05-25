using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IOrdersView
{
    OrdersDataModel Model { set; }

    event EventHandler<int> EditRequested;
    event EventHandler<int> DeleteRequested;
    event EventHandler CloseRequested;
    event EventHandler LoadRequested;

    void Close();
}

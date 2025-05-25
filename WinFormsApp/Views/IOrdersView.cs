using WinFormsApp.Models;
using Models;

namespace WinFormsApp.Views;

public interface IOrdersView
{
    OrdersDataModel Model { set; }

    event EventHandler<OrderModel> StatusChangeRequested;
    event EventHandler<int> DeleteRequested;
    event EventHandler CloseRequested;
    event EventHandler LoadRequested;

    void Close();
}

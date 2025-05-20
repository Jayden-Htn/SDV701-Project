using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IProductItemView
{
    ProductDataModel Model { set; }

    event EventHandler EditRequested;
    event EventHandler DeleteRequested;
    event EventHandler LoadRequested;

    void Close();
}

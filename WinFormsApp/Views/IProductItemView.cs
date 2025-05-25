using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IProductItemView
{
    ProductDataModel Model { set; }

    public event EventHandler<int> EditRequested;
    public event EventHandler<int> DeleteRequested;

}

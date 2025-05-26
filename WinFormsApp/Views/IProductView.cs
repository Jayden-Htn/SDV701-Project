using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IProductView
{
    ProductDataModel Model { get; set; }

    public event EventHandler AddRequested;
    public event EventHandler<int> EditRequested;
    public event EventHandler<int> DeleteRequested;
    public event EventHandler CloseRequested;
    public event EventHandler LoadRequested;

    void Close();
}

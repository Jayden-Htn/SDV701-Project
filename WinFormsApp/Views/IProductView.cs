using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views;

public interface IProductView
{
    ProductDataModel Model { get; set; }

    public event EventHandler<ILawnmowerModel> SaveRequested;
    public event EventHandler CloseRequested;
    public event EventHandler LoadRequested;

    void Close();
    DialogResult ShowDialog();
}

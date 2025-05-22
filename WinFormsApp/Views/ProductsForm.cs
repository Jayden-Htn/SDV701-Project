using WinFormsApp.Models;

namespace WinFormsApp.Views;

public partial class ProductsForm : Form, IProductsView
{
    public event EventHandler AddRequested;
    public event EventHandler<int> EditRequested;
    public event EventHandler<int> DeleteRequested;
    public event EventHandler QuitRequested;
    public event EventHandler LoadRequested;

    public ProductsForm()
    {
        InitializeComponent();

        AddButton.Click += OnAddButtonClick;
        QuitButton.Click += OnQuitButtonClick;
        Load += OnFormLoad;
    }

    public ProductsDataModel Model
    {
        set
        {
            foreach (var product in value?.Lawnmowers)
            {
                var item = new ProductItemControl();
                item.SetData(product);
                ProductsPanel.Controls.Add(item);
            }
        }
    }
    private void OnAddButtonClick(object sender, EventArgs e)
    {
        AddRequested?.Invoke(this, EventArgs.Empty);
    }

    private void OnQuitButtonClick(object sender, EventArgs e)
    {
        QuitRequested?.Invoke(this, EventArgs.Empty);
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
        LoadRequested?.Invoke(this, EventArgs.Empty);
    }
}

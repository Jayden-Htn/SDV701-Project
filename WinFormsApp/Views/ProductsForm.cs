using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views;

public partial class ProductsForm : Form, IProductsView
{
    public event EventHandler AddRequested;
    public event EventHandler QuitRequested;
    public event EventHandler LoadRequested;
    public event EventHandler<int> FilterRequested;
    public event EventHandler<ILawnmowerModel> EditRequested;
    public event EventHandler<int> DeleteRequested;
    public event EventHandler ViewOrders;

    public ProductsForm()
    {
        InitializeComponent();

        AddButton.Click += OnAddButtonClick;
        QuitButton.Click += OnQuitButtonClick;
        FilterCombo.SelectedValueChanged += OnBrandFilterChange;
        Load += OnFormLoad;
    }

    public ProductsDataModel Model
    {
        set
        {
            SetData(value);
        }
    }

    private void SetData(ProductsDataModel value)
    {
        // Set brand filter
        BrandModel newBrand = new()
        {
            Id = 0,
            Name = "All",
            Description = "View every lawnmower we have in stock."
        };

        BrandModel[] brands = new[] { newBrand }
            .Concat(value.Brands)
            .ToArray();

        FilterCombo.Items.Clear();
        FilterCombo.Items.AddRange(brands);
        FilterCombo.DisplayMember = "Name";
        FilterCombo.ValueMember = "Id";
        FilterCombo.SelectedIndex = value.CurrentBrandId; // Should fix id/index being used interchangeably

        // Set products
        ProductsPanel.Controls.Clear();

        foreach (var product in value?.Lawnmowers)
        {
            var item = new ProductItemControl();
            item.SetData(product);

            item.EditRequested += (obj, model) =>
            {
                EditRequested?.Invoke(this, model);
            };
            item.DeleteRequested += (obj, id) =>
            {
                DeleteRequested?.Invoke(this, id);
            };

            ProductsPanel.Controls.Add(item);
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

    private void OnBrandFilterChange(object sender, EventArgs e)
    {
        if (FilterCombo.SelectedItem != null)
        {
            BrandModel brand = FilterCombo.SelectedItem as BrandModel;
            FilterRequested?.Invoke(this, brand.Id);
        }
    }

    private void OnFormLoad(object sender, EventArgs e)
    {
        LoadRequested?.Invoke(this, EventArgs.Empty);
    }

    private void OrdersButton_Click(object sender, EventArgs e)
    {
        ViewOrders?.Invoke(this, EventArgs.Empty);
    }
}

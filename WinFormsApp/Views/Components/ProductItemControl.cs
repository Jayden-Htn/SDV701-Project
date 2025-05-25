using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views;

public partial class ProductItemControl : UserControl, IProductItemView
{
    public event EventHandler<int> EditRequested;
    public event EventHandler<int> DeleteRequested;

    private LawnmowerModel _model;

    public ProductItemControl()
    {
        InitializeComponent();

        EditButton.Click += OnEditButtonClick;
        DeleteButton.Click += OnDeleteButtonClick;
    }

    public ProductDataModel Model
    {
        set
        {
            SetData(value.Lawnmower);
        }
    }

    public void SetData(LawnmowerModel product)
    {
        _model = product;

        NameLabel.Text = product.Name;
        DescriptionLabel.Text = product.Description;
        PriceLabel.Text = $"{product.Price.ToString("C")}";
        StockLabel.Text = $"{product.QuantityInStock} available";
        BrandLabel.Text = product.Brand.Name;
        TypeLabel.Text = product.Type;

        //if (product.Photo != null)
        //{
        //    ImageBox.Image = product.Photo;
        //}
    }

    public void OnEditButtonClick(object sender, EventArgs e)
    {
        EditRequested?.Invoke(this, _model.Id);
    }

    public void OnDeleteButtonClick(object sender, EventArgs e)
    {
        DeleteRequested?.Invoke(this, _model.Id);
    }
}

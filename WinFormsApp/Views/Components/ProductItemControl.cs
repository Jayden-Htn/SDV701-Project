using Models;

namespace WinFormsApp.Views;

public partial class ProductItemControl : UserControl
{
    public ProductItemControl()
    {
        InitializeComponent();
    }

    public void SetData(LawnmowerModel product)
    {
        NameLabel.Text = product.Name;
        DescriptionLabel.Text = product.Description;
        PriceLabel.Text = $"${product.Price}";
        StockLabel.Text = $"{product.QuantityInStock} available";
        //BrandLabel.Text = product.Brand.Name;
        TypeLabel.Text = product.Type;
        //ImageBox.Image = product.Photo;
    }
}

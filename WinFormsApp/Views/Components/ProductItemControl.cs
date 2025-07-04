﻿using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views;

public partial class ProductItemControl : UserControl, IProductItemView
{
    public event EventHandler<ILawnmowerModel> EditRequested;
    public event EventHandler<int> DeleteRequested;

    private ILawnmowerModel _model;

    public ProductDataModel Model
    {
        set
        {
            SetData(value.Lawnmower);
        }
    }

    public ProductItemControl()
    {
        InitializeComponent();

        EditButton.Click += OnEditButtonClick;
        DeleteButton.Click += OnDeleteButtonClick;
    }

    public void SetData(ILawnmowerModel product)
    {
        _model = product;

        NameLabel.Text = product.Name;
        DescriptionLabel.Text = product.Description;
        PriceLabel.Text = $"{product.Price.ToString("C")}";
        StockLabel.Text = $"{product.QuantityInStock} available";
        BrandLabel.Text = product.Brand.Name;
        TypeLabel.Text = product.Type;

        if (product.Photo != null)
        {
            byte[] bytes = Convert.FromBase64String(product.Photo);
            using (var ms = new MemoryStream(bytes))
            {
                ImageBox.Image = Image.FromStream(ms);
            }
        }
    }

    public void OnEditButtonClick(object sender, EventArgs e)
    {
        EditRequested?.Invoke(this, _model);
    }

    public void OnDeleteButtonClick(object sender, EventArgs e)
    {
        DeleteRequested?.Invoke(this, _model.Id);
    }
}

using Models;

namespace WinFormsApp.Views.Components
{
    public partial class OrderItemControl : UserControl
    {
        public OrderItemControl()
        {
            InitializeComponent();
        }

        public void SetData(OrderModel order)
        {
            IdLabel.Text = order.Id.ToString();
            ProductLabel.Text = order.Product.Name;
            BrandLabel.Text = order.Product.Brand.Name;
            PriceLabel.Text = $"{order.Quantity} per item";
            QuantityLabel.Text = $"x{order.Quantity} items";
            TotalPriceLabel.Text = $"Total: {order.Quantity*order.ItemPrice} items";
            CustomerNameLabel.Text = order.CustomerName;
            CustomerEmailLabel.Text = order.CustomerEmail;
            CustomerPhoneLabel.Text = order.CustomerPhone;
            DateOrderedLabel.Text = order.TimeCreated.ToString();
            CompleteCheckbox.Checked = order.Completed;
        }
    }
}

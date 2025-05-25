using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views.Components
{
    public partial class OrderItemControl : UserControl
    {
        public event EventHandler<OrderModel> StatusChangeRequested;
        public event EventHandler<int> DeleteRequested;

        private OrderModel _model;

        public OrderDataModel Model
        {
            set
            {
                SetData(value.Order);
            }
        }

        public OrderItemControl()
        {
            InitializeComponent();
        }


        public void SetData(OrderModel order)
        {
            _model = order;
            IdLabel.Text = order.Id.ToString();
            ProductLabel.Text = order.Product.Name;
            BrandLabel.Text = order.Product.Brand.Name;
            PriceLabel.Text = $"{order.ItemPrice.ToString("C")} per item";
            QuantityLabel.Text = $"x{order.Quantity} items";
            TotalPriceLabel.Text = $"Total: {(order.Quantity * order.ItemPrice).ToString("C")}";
            CustomerNameLabel.Text = order.CustomerName;
            CustomerEmailLabel.Text = order.CustomerEmail;
            CustomerPhoneLabel.Text = order.CustomerPhone;
            DateOrderedLabel.Text = order.TimeCreated.ToString();
            CompleteCheckbox.Checked = order.Completed;
        }

        public void CompleteCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _model.Completed = CompleteCheckbox.Checked;
            StatusChangeRequested?.Invoke(this, _model);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteRequested?.Invoke(this, _model.Id);
        }
    }
}

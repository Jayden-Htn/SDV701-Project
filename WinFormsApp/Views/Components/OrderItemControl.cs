using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views.Components
{
    public partial class OrderItemControl : UserControl
    {
        public event EventHandler<int> StatusChangeRequested;
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

        //public void OnChangeStatusClick(object sender, EventArgs e)
        //{
        //    ChangeStatusRequested?.Invoke(this, _model.Id);
        //}  

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteRequested?.Invoke(this, _model.Id);
        }
    }
}

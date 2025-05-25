using WinFormsApp.Models;
using WinFormsApp.Views.Components;

namespace WinFormsApp.Views
{
    public partial class OrdersForm : Form, IOrdersView
    {
        public event EventHandler AddRequested;
        public event EventHandler<int> StatusChangeRequested;
        public event EventHandler<int> DeleteRequested;
        public event EventHandler CloseRequested;
        public event EventHandler LoadRequested;

        public OrdersForm()
        {
            InitializeComponent();

            CloseButton.Click += OnCloseButtonClick;
            Load += OnOrdersFormLoad;
        }

        public OrdersDataModel Model
        {
            set
            {
                SetData(value);
            }
        }

        private void SetData(OrdersDataModel value)
        {
            OrdersPanel.Controls.Clear();

            foreach (var order in value?.Orders)
            {
                var item = new OrderItemControl();
                item.SetData(order);

                item.StatusChangeRequested += (obj, id) =>
                {
                    StatusChangeRequested?.Invoke(this, id);
                };
                item.DeleteRequested += (obj, id) =>
                {
                    DeleteRequested?.Invoke(this, id);
                };

                OrdersPanel.Controls.Add(item);
            }

            TotalValueLabel.Text = $"Total: {value?.TotalValue.ToString("C")}";
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnOrdersFormLoad(object sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

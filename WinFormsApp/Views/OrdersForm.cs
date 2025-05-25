using WinFormsApp.Models;
using WinFormsApp.Views.Components;

namespace WinFormsApp.Views
{
    public partial class OrdersForm : Form, IOrdersView
    {
        public event EventHandler AddRequested;
        public event EventHandler<int> EditRequested;
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
                foreach (var order in value?.Orders)
                {
                    var item = new OrderItemControl();
                    item.SetData(order);
                    OrdersPanel.Controls.Add(item);
                }

                TotalValueLabel.Text = $"Total: {value?.TotalValue.ToString("C")}";
            }
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

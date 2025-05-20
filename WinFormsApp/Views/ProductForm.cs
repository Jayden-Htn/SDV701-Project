using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views
{
    public partial class ProductForm : Form, IProductView
    {
        public event EventHandler AddRequested;
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;
        public event EventHandler QuitRequested;
        public event EventHandler LoadRequested;

        public ProductForm()
        {
            InitializeComponent();

            SaveButton.Click += OnSaveButtonClick;
            CloseButton.Click += OnCloseButtonClick;
            Load += OnMainFormLoad;
        }

        public ProductDataModel Model
        {
            set
            {
                var product = value.Lawnmower;
                NameInput.Text = product.Name;
                PriceInput.Text = product.Price.ToString();
                StockNumeric.Value = product.QuantityInStock;
                BrandCombo.Items.Clear();
                // BrandCombo.Items = new List<string>() { "Tooler", "MowGo" }; // Ideally get from db
                TypeCombo.Items.Clear();
                // TypeCombo.Items = new List<string>() { "Push", "Ride On" }; // Ideally get from db
                FuelDetailsInput.Text = product.FuelDetails;
                LastUpdatedLabel.Text = product.LastUpdated.ToString();

                // Need to handle type specific field
            }
            get { return Model; }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            AddRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            //QuitRequested?.Invoke(this, EventArgs.Empty);
        }

        public LawnmowerModel GetData()
        {
            LawnmowerModel product;
            if (TypeCombo.SelectedText == "Push")
            {
                product = new PushLawnmowerModel();
            } else
            {
                product = new RideOnLawnmowerModel();
            }

            product.Name = NameInput.Text;
            product.Price = Convert.ToDecimal(PriceInput.Text);
            product.QuantityInStock = (int)StockNumeric.Value;
            product.BrandId = BrandCombo.SelectedIndex + 1;
            product.FuelDetails = FuelDetailsInput.Text;
            product.LastUpdated = DateTime.Now;
            return product;
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

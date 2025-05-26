using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views
{
    public partial class ProductForm : Form, IProductView
    {
        public event EventHandler AddRequested;
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;
        public event EventHandler CloseRequested;
        public event EventHandler LoadRequested;

        private ProductDataModel _model;

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
                _model = value;
                SetData(value);
                
            }
            get { return _model; }
        }

        private void SetData(ProductDataModel value)
        {
            var product = value.Lawnmower;
            NameInput.Text = product.Name;
            DescriptionInput.Text = product.Description;
            PriceNumeric.Value = product.Price;
            StockNumeric.Value = product.QuantityInStock;            
            FuelDetailsInput.Text = product.FuelDetails;
            LastUpdatedLabel.Text = product.LastUpdated.ToString();

            TypeInput.Text = product.Type;

            BrandCombo.DataSource = null;
            BrandCombo.DataSource = value.Brands;
            BrandCombo.DisplayMember = "Name";
            BrandCombo.ValueMember = "Id";
            if (product.BrandId != 0)
            {
                BrandCombo.SelectedValue = product.BrandId;
            }

            if (product.Type == "RideOn")
            {
                TypeSpecificLabel.Text = "Max Speed (km/h)";
                TypeSpecificNumeric.Value = (product as RideOnLawnmowerModel).TopSpeed;
            }
            else if (product.Type == "Push")
            {
                TypeSpecificLabel.Text = "Weight (kg)";
                TypeSpecificNumeric.Value = (product as PushLawnmowerModel).Weight; ;
            }
            else
            {
                TypeSpecificLabel.Text = "";
                TypeSpecificNumeric.Value = 0;
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            AddRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public LawnmowerModel GetData()
        {
            LawnmowerModel product;
            if (TypeInput.SelectedText == "Push")
            {
                product = new PushLawnmowerModel();
            } else
            {
                product = new RideOnLawnmowerModel();
            }

            product.Name = NameInput.Text;
            product.Price = Convert.ToDecimal(PriceNumeric.Value);
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

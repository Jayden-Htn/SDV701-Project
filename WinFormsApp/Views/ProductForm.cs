using Models;
using WinFormsApp.Models;

namespace WinFormsApp.Views
{
    public partial class ProductForm : Form, IProductView
    {
        public event EventHandler<ILawnmowerModel> SaveRequested;
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
            LastUpdatedLabel.Text = $"Last updated: {product.LastUpdated.ToString()}";

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
            SaveRequested?.Invoke(this, GetData());
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public ILawnmowerModel GetData()
        {
            ILawnmowerModel product;
            if (TypeInput.Text == "Push")
            {
                var prod = new PushLawnmowerModel();
                prod.Weight = (int)TypeSpecificNumeric.Value;
                product = prod;

            } 
            else if (TypeInput.Text == "RideOn")
            {
                var prod = new RideOnLawnmowerModel();
                prod.TopSpeed = (int)TypeSpecificNumeric.Value;
                product = prod;
            }
            else
            {
                product = new LawnmowerModel();
            }

            product.Id = _model.Lawnmower.Id;
            product.Name = NameInput.Text;
            product.Description = DescriptionInput.Text;
            product.BrandId = (int)BrandCombo.SelectedValue;
            product.Brand= (BrandModel)BrandCombo.SelectedItem;
            product.Price = Convert.ToDecimal(PriceNumeric.Value);
            product.QuantityInStock = (int)StockNumeric.Value;
            product.Photo = null;
            product.FuelDetails = FuelDetailsInput.Text;
            product.Type = TypeInput.Text;
            product.LastUpdated = DateTime.Now;

            return product;
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

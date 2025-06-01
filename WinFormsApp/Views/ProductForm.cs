using Models;
using System.Drawing.Imaging;
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

            // Base details
            NameInput.Text = product.Name;
            DescriptionInput.Text = product.Description;
            PriceNumeric.Value = product.Price;
            StockNumeric.Value = product.QuantityInStock;            
            FuelDetailsInput.Text = product.FuelDetails;

            // Date
            if (value.Lawnmower.Id == 0)
            {
                LastUpdatedLabel.Text = "Creating product";
            }
            else
            {
                LastUpdatedLabel.Text = $"Last updated: {product.LastUpdated.ToString()}";
            }

            // Brand
            BrandCombo.DataSource = null;
            BrandCombo.DataSource = value.Brands;
            BrandCombo.DisplayMember = "Name";
            BrandCombo.ValueMember = "Id";
            if (product.BrandId != 0)
            {
                BrandCombo.SelectedValue = product.BrandId;
            }

            // Type specific
            if (product is RideOnLawnmowerModel rideOn)
            {
                TypeSpecificLabel.Text = "Max Speed (km/h)";
                TypeSpecificNumeric.Value = rideOn.TopSpeed;
                TypeInput.Text = "RideOn";
            }
            else if (product is PushLawnmowerModel push)
            {
                TypeSpecificLabel.Text = "Weight (kg)";
                TypeSpecificNumeric.Value = push.Weight; ;
                TypeInput.Text = "Push";
            }
            else
            {
                TypeSpecificLabel.Text = "";
                TypeSpecificNumeric.Value = 0;
            }

            // Photo
            if (product.Photo != null) {
                byte[] bytes = Convert.FromBase64String(product.Photo);
                using (var ms = new MemoryStream(bytes))
                {
                    ImageBox.Image = Image.FromStream(ms);
                }
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs e)
        {
            ILawnmowerModel model = GetData();

            if (model.Name.Length == 0 || model.FuelDetails.Length == 0 || model.FuelDetails.Length == 0)
            {
                MessageBox.Show("Missing form data", "Error");
            }
            else
            {
                SaveRequested?.Invoke(this, model);
            }
        }

        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }

        public ILawnmowerModel GetData()
        {
            ILawnmowerModel product;

            // Type specific
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

            // Base
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

            // Image
            if (ImageBox.Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    ImageBox.Image.Save(ms, ImageFormat.Png);
                    product.Photo = Convert.ToBase64String(ms.ToArray());
                }
            }

            return product;
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

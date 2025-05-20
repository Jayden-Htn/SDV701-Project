using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.Models;
using WinFormsApp.Views.Components;

namespace WinFormsApp.Views
{
    public partial class ProductsForm : Form, IProductsView
    {
        public event EventHandler AddRequested;
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;
        public event EventHandler QuitRequested;
        public event EventHandler LoadRequested;

        public ProductsForm()
        {
            InitializeComponent();

            AddButton.Click += OnAddButtonClick;
            QuitButton.Click += OnQuitButtonClick;
            Load += OnMainFormLoad;
        }

        public ProductsDataModel Model
        {
            set
            {
                foreach (var product in value?.Lawnmowers)
                {
                    var item = new ProductItemControl();
                    item.SetData(product);
                    ProductsPanel.Controls.Add(item);
                }
            }
        }
        private void OnAddButtonClick(object sender, EventArgs e)
        {
            AddRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnQuitButtonClick(object sender, EventArgs e)
        {
            QuitRequested?.Invoke(this, EventArgs.Empty);
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            LoadRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DppInventory
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadDataGrid(null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataProductForm _dataProductForm = DataProductForm.Instance;

            _dataProductForm.ShowDialog();

        }

        private void LoadDataGrid(string data)
        {
            List<Product> list = new List<Product>();
            ProductController _productController = new ProductController();
            productGridView.DataSource = _productController.Query(data);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string data = txtSearch.Text;
            LoadDataGrid(data);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataGrid(null);
        }
    }
}

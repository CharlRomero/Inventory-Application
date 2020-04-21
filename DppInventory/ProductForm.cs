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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataProductForm _dataProductForm = DataProductForm.Instance;

            _dataProductForm.ShowDialog();

        }

        private void loadDataGrid(string data)
        {
            List<Product> list = new List<Product>();
            ProductController _productController = new ProductController();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

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
    public partial class ProvederForm : Form
    {
        public ProvederForm()
        {
            InitializeComponent();
            LoadDataGrid(null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDataGrid(string data)
        {
            List<Proveder> list = new List<Proveder>();
            ProvederController _provederController = new ProvederController();
            provederDataGrid.DataSource = _provederController.Query(data);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool check;

            Proveder _proveder = new Proveder
            {
                Name = txtName.Text,
                TelfNumber = txtTelfNumber.Text,
                Email = txtEmail.Text
            };

            ProvederController controller = new ProvederController();

            if (txtId.Text != "")
            {
                _proveder.Id = int.Parse(txtId.Text);
                check = controller.upDate(_proveder);
            }
            else
            {
                check = controller.insert(_proveder);
            }

            if (check)
            {
                MessageBox.Show("Registro Guardado");
                cleanTxt();
                LoadDataGrid(null);
            }
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

        private void cleanTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtTelfNumber.Text = "";
            txtEmail.Text = "";
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(warning() == DialogResult.Yes)
            {
                txtId.Text = provederDataGrid.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = provederDataGrid.CurrentRow.Cells[1].Value.ToString();
                txtTelfNumber.Text = provederDataGrid.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = provederDataGrid.CurrentRow.Cells[3].Value.ToString();
            }            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool check;

            if(warning() == DialogResult.Yes)
            {
                string name = provederDataGrid.CurrentRow.Cells[1].ToString();

                ProvederController _controller = new ProvederController();
                check = _controller.delete(name);

                if (check)
                {
                    MessageBox.Show("Registro Eliminado");
                    cleanTxt();
                    LoadDataGrid(null);
                }
            }
        }

        private DialogResult warning()
        {
            return MessageBox.Show("¿Desea continuar?", "Salir", MessageBoxButtons.YesNoCancel);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            cleanTxt();
        }
    }
}

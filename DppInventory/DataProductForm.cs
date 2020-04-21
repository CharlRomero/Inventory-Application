using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace DppInventory
{
    public partial class DataProductForm : Form
    {
        private readonly static DataProductForm _instance = new DataProductForm();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private DataProductForm()
        {
            InitializeComponent();
        }

        public static DataProductForm Instance
        {
            get
            {
                return _instance;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            addToDB();
            cleanTxt();
        }

        private void addToDB()
        {
            string id = "XXXX"; //This id it'll generate automatically 
            string name = txtName.Text;
            int stock = (int) numericStock.Value;
            double price = double.Parse(txtPrice.Text);

            string sql = "INSERT TO product (id_p, name_p, stock_p, price_p) VALUES ('"+ id + "', '" + name + "', '" + stock + "', '" + price + "')";

            MySqlConnection conexionDB = Connection.connection();
            conexionDB.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sql, conexionDB);
                command.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar: \n" + ex.Message);
            }
            finally
            {
                conexionDB.Close();
            }

        }

        private void cleanTxt()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            numericStock.Value = 0;
        }
    }
}

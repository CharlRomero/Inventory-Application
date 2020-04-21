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
    public partial class DataProvederForm : Form
    {
        private readonly static DataProvederForm _instance = new DataProvederForm();

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private DataProvederForm()
        {
            InitializeComponent();
        }

        public static DataProvederForm Instance
        {
            get
            {
                return _instance;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            addToDB();
            cleanTxt();
        }

        private void addToDB()
        {
            string name = txtName.Text;
            string telfNumber = txtTelfNumber.Text;
            string email = txtEmail.Text;

            string sql = "INSERT INTO proveder (name_pr, telf_number_pr, email_pr) VALUES ('" + name + "', '" + telfNumber + "', '" + email + "')";

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
            txtTelfNumber.Text = "";
            txtEmail.Text = "";
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        
    }
}

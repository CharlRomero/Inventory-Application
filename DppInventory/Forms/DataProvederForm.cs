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
            bool check = false;

            Proveder _proveder = new Proveder();
            _proveder.Name = txtName.Text;
            _proveder.TelfNumber = txtTelfNumber.Text;
            _proveder.Email = txtEmail.Text;
            
            ProvederController controller = new ProvederController();

            if (txtName.Text != "")
            {
                _proveder.Name = txtName.Text;
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

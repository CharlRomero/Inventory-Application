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

namespace DppInventory
{
    public partial class PrincipalForm : Form
    {

        public PrincipalForm()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnSlide_Click(object sender, EventArgs e)
        {
            if (verticalPanel.Width == 250)
            {
                verticalPanel.Width = 60;
            }
            else
                verticalPanel.Width = 250;
        }

        private void openFormInPanel(object sonForm)
        {
            if (this.managerPanel.Controls.Count > 0)
                this.managerPanel.Controls.RemoveAt(0);
            Form sf = sonForm as Form;
            sf.TopLevel = false;
            sf.Dock = DockStyle.Fill;
            this.managerPanel.Controls.Add(sf);
            this.managerPanel.Tag = sf;
            sf.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.Visible = true;
            btnMaximize.Visible = false;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestore.Visible = false;
            btnMaximize.Visible = true;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            openFormInPanel(new ProductForm());
        }

        private void btnProveder_Click(object sender, EventArgs e)
        {
            openFormInPanel(new ProvederForm());
        }
    }
}

﻿using System;
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
            bool check = false;

            Product _product = new Product();
            _product.Id = _product.generateId(_product.Name);
            _product.Name = txtName.Text;
            _product.Stock = (int)numericStock.Value;
            _product.Price = double.Parse(txtPrice.Text);

            ProductController controller = new ProductController();

            if (txtId.Text != "")
            {
                _product.Id = txtId.Text;
                check = controller.upDate(_product);
            }
            else
            {
                check = controller.insert(_product);
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
            txtPrice.Text = "";
            numericStock.Value = 0;
        }
    }
}

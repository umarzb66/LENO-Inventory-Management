using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leno_Inventory_Management
{
    public partial class mainform1 : Form
    {
        public mainform1()
        {
            InitializeComponent();
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void OpenForm<MyForm>() where MyForm : Form, new()
        {
            Form form;
            form = guna2Panel3.Controls.OfType<MyForm>().FirstOrDefault();//Search the form in the collection
                                                                          //if the form/instance does not exist
            if (form == null)
            {
                form = new MyForm();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                guna2Panel3.Controls.Add(form);
                guna2Panel3.Tag = form;
                form.Show();
                form.BringToFront();
            }
            //if the form/instance exists
            else
            {
                form.BringToFront();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenForm<Form1Dash>();
            Form1Dash form1dash = new Form1Dash();
            form1dash.Refresh();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenForm<Form2Stock>();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenForm<Form3Purchase>();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenForm<Form14stockout>();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenForm<Form6Bills>();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            OpenForm<Form4Workers>();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            OpenForm<Form5Traveler>();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            OpenForm<Form8Controlpanel>();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            OpenForm<Form9About>();
        }

        private void gunaSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            OpenForm<Form7Profile>();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            OpenForm<Form11Customer>();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            OpenForm<Form13vendor>();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            OpenForm<Form10BankAC>();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            OpenForm<Form12rawmaterials>();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainform1_Load(object sender, EventArgs e)
        {
            OpenForm<Form1Dash>();
            Form1Dash form1dash = new Form1Dash();
            form1dash.Refresh();
        }
    }
}

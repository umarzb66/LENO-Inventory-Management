using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Leno_Inventory_Management
{
    public partial class login : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");
        int count = 0;
        public login()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from loginTable where userid='" + txtuser.Text + "' AND pass='" + txtpass.Text + "'  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());

            if (count == 0)
            {
                MessageBox.Show("User Id & Password Not Match");
            }
            else
            {
                this.Hide();
            mainform1 main = new mainform1();
            main.Show();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();
        }

        private void txtpass_Load(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
        }

        private void txtpass_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtpass.Text == "Enter Password")
            {
                txtpass.Clear();
                txtpass.PasswordChar = '*';
            }
        }

        private void txtuser_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtuser.Text == "Enter User Id")
            {
                txtuser.Clear();
            }
        }
    }
}

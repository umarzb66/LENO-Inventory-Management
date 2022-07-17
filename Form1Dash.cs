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
    public partial class Form1Dash : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1Dash()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //int sum = Convert.ToInt32(dt.Compute("SUM(Salary)", string.Empty));
        }
        async void TimeUpdater()
        {
            while (true)
            {
                time.Text = DateTime.Now.ToString("hh : mm : ss tt");
                await Task.Delay(1000);
            }
        }
        private void stockinsum()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(quantity) from stockTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            stockin.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(stockin.Text))
            {
                stockin.Text = "0";
            }
            else
            {
                stockin.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void stockoutsum()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(sold) from stockoutTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            stockout.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(stockout.Text))
            {
                stockout.Text = "0";
            }
            else
            {
                stockout.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void purchasesum()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(totalamount) from purchaseTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            purchase.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(purchase.Text))
            {
                purchase.Text = "0";
            }
            else
            {
                purchase.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void workerpaidsum()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(paid) from workerTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            workerpaid.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(workerpaid.Text))
            {
                workerpaid.Text = "0";
            }
            else
            {
                workerpaid.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void travellingsum()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(cost) from travellerTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            travelling.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(travelling.Text))
            {
                travelling.Text = "0";
            }
            else
            {
                travelling.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
        private void totalearnsum()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(totalamount) from billTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            total.Text = dt.Rows[0][0].ToString();
            if (string.IsNullOrWhiteSpace(total.Text))
            {
                total.Text = "0";
            }
            else
            {
                total.Text = dt.Rows[0][0].ToString();
            }
            Con.Close();
        }
       
        private void Form1Dash_Load(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from profileTable ", Con);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            workercount.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from customerTable ", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            customercount.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from vendorTable ", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            vendorcount.Text = dt3.Rows[0][0].ToString();
            Con.Close();
            stockinsum();
            stockoutsum();
            TimeUpdater();
            purchasesum();
            workerpaidsum();
            travellingsum();
            totalearnsum();
         
        }
    }
}

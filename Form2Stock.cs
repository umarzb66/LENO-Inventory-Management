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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace Leno_Inventory_Management
{
    public partial class Form2Stock : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form2Stock()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from stockTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            stockDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (modelno.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stockTable values ('" + modelno.Text + "'," + capacity.Text + "," + weight.Text + ",'" + dimension.Text + "'," + tax.Text + "," + price.Text + "," + quantity.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Stock Details Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (modelno.Text == "" )

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update stockTable set  capacity =" + capacity.Text + ", weight = " +weight.Text + ",  dimension='" + dimension.Text + "',tax =" + tax.Text + ",price=" + price.Text + ",quantity =" + quantity.Text + "where modelno='" + modelno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Stock Details  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (modelno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from stockTable where modelno = '" + modelno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            modelno.Text = "";
            capacity.Text = "";
            weight.Text = "";
            dimension.Text = "";
            tax.Text = "";
            price.Text = "";
            quantity.Text = "";
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (modelno.Text == "")
            {
                MessageBox.Show("Enter Model No ");
            }
            else
            {
                Con.Open();
                string query = "select * from stockTable where modelno='" + modelno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    capacity.Text = dr["capacity"].ToString();
                    weight.Text = dr["weight"].ToString();
                    dimension.Text = dr["dimension"].ToString();
                    tax.Text = dr["tax"].ToString();
                    price.Text = dr["price"].ToString();
                    quantity.Text = dr["quantity"].ToString();              
                }
                Con.Close();
            }
        }

        private void Form2Stock_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void capacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void modelno_TextChanged(object sender, EventArgs e)
        {

        }

        private void modelno_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void weight_TextChanged(object sender, EventArgs e)
        {

        }

        private void weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void dimension_TextChanged(object sender, EventArgs e)
        {

        }

        private void dimension_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void price_TextChanged(object sender, EventArgs e)
        {

        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(stockDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in stockDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in stockDGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documento PDF (*.pdf)|*.pdf";
            sfd.FileName = DateTime.Now.ToString("dd-MM-yyyy");

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                string filename = sfd.FileName;
                FileStream file = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, file);
                doc.Open();
                doc.Add(pdfTable);
                doc.Close();
                System.Diagnostics.Process.Start(sfd.FileName);

            }
        }
    }
}
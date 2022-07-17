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
    public partial class Form14stockout : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form14stockout()
        {
            InitializeComponent();
        }
        private void automodel()
        {
            Con.Open();
            string sqlquery = "select modelno From stockTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            modelno.AutoCompleteMode = AutoCompleteMode.Suggest;
            modelno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            modelno.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from stockoutTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            stockoutDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void updatestock()
        {
            if (modelno.Text == "")
            {
                MessageBox.Show("Enter Model No");
            }
            else
            {
                int quantity, newquantity,num;
                Con.Open();
                string query = "select * from stockTable where modelno='" + modelno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    num = Convert.ToInt32(sold.Text);
                    quantity = Convert.ToInt32(dr["quantity"].ToString());
                    newquantity = quantity - num;
                    string query1 = "update stockTable set quantity=" + newquantity+ " where modelno='" + modelno.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, Con);
                    cmd1.ExecuteNonQuery();

                }
                Con.Close();
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (idno.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Solddate = solddate.Value.Day.ToString() + "/" + solddate.Value.Month.ToString() + "/" + solddate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Solddate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into stockoutTable values (" + idno.Text + ",'" + modelno.Text + "'," + billno.Text + ",'" + invoiceno.Text + "','" + date.ToString("MM-dd-yyyy") + "','" + companyname.Text + "'," + sold.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Stock Out Details Added Succesfully");
                Con.Close();
                updatestock();
                populate();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (idno.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Solddate = solddate.Value.Day.ToString() + "/" + solddate.Value.Month.ToString() + "/" + solddate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Solddate);
                Con.Open();
                string query = "update stockoutTable set  modelno ='" + modelno.Text + "', billno = " + billno.Text + ",  invoiceno='" + invoiceno.Text + "',date ='" + date.ToString("MM-dd-yyyy") + "',company='" + companyname.Text + "'where idno='" + idno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Succesfully Updated");
                Con.Close();
                populate();

            }
        }
        private void deletestock()
        {
            if (modelno.Text == "")
            {
                MessageBox.Show("Enter Model No");
            }
            else
            {
                int quantity, newquantity,num;
                Con.Open();
                string query = "select * from stockTable where modelno='" + modelno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                 
                    num = Convert.ToInt32(sold.Text);
                    quantity = Convert.ToInt32(dr["quantity"].ToString());
                    newquantity = quantity + num;
                    string query1 = "update stockTable set quantity=" + newquantity+ " where modelno='" + modelno.Text + "'";
                    SqlCommand cmd1 = new SqlCommand(query1, Con);
                    cmd1.ExecuteNonQuery();

                }
                Con.Close();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            deletestock();
            if (idno.Text == "")
            {

            }
            else
            {
                
                Con.Open();
                String query = "delete from stockoutTable where idno = '" + idno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
               
                populate();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            idno.Text = "";
            modelno.Text = "";
            billno.Text = "";
            invoiceno.Text = "";
            solddate.Text = "";
            companyname.Text = "";
            sold.Text = "";
            }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (idno.Text == "")
            {
                MessageBox.Show("Enter Id No ");
            }
            else
            {
                Con.Open();
                string query = "select * from stockoutTable where idno='" + idno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    modelno.Text = dr["modelno"].ToString();
                    billno.Text = dr["billno"].ToString();
                    invoiceno.Text = dr["invoiceno"].ToString();
                    solddate.Text = dr["date"].ToString();
                    companyname.Text = dr["company"].ToString();
                    sold.Text = dr["sold"].ToString();
                }
                Con.Close();
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (billno.Text == "")
            {
                MessageBox.Show("Enter Bill No ");
            }
            else
            {
                Con.Open();
                string query = "select * from billTable where billno='" + billno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    invoiceno.Text = dr["invoiceno"].ToString();
                    solddate.Text = dr["date"].ToString();
                    companyname.Text = dr["company"].ToString();                   
                }
                Con.Close();
            }
        }

        private void Form14stockout_Load(object sender, EventArgs e)
        {
            populate();
            automodel();
        }

        private void idno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void billno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void invoiceno_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void companyname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void sold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(stockoutDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in stockoutDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in stockoutDGV.Rows)
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

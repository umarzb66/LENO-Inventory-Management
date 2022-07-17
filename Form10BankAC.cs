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
    public partial class Form10BankAC : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form10BankAC()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from bankdetailsTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            bankDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
          
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            if (empno.Text == "" || name.Text == "" || category.Text == "" || phoneno.Text == "" || bankacno.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update bankdetailsTable set  name ='" + name.Text + "', category = '" + category.Text + "',  phoneno=" + phoneno.Text + ",bankacno ='" + bankacno.Text + "',bankname='" + bankname.Text + "',branchname ='" + branchname.Text + "',ifsccode='" + ifsccode.Text + "',micrcode='" + micrcode.Text + "', status =' " + status.Text + "'where empno=" + empno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bank Details  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (empno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from bankdetailsTable where empno = " + empno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();
                }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            empno.Text = "";
            name.Text = "";
            category .Text = "";
            phoneno.Text = "";
            bankacno.Text = "";
            bankname .Text = "";
            branchname .Text = "";
            ifsccode .Text = "";
            micrcode .Text = "";
            status .Text = "";
           
        }

        private void refersh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (empno.Text == "")
            {
                MessageBox.Show("Enter Employee No ");
            }
            else
            {
                Con.Open();
                string query = "select * from profileTable where empno=" + empno.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    name.Text = dr["name"].ToString();
                    category.Text = dr["category"].ToString();
                    phoneno.Text = dr["phoneno"].ToString();
                }
                Con.Close();
            }
        }

        private void Form10BankAC_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void searchhere_Click(object sender, EventArgs e)
        {
            if (empno.Text == "")
            {
                MessageBox.Show("Enter Employee No ");
            }
            else
            {
                Con.Open();
                string query = "select * from bankdetailsTable where empno=" + empno.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    name.Text = dr["name"].ToString();
                    category.Text = dr["category"].ToString();
                    phoneno.Text = dr["phoneno"].ToString();
                    bankacno.Text = dr["bankacno"].ToString();
                    bankname.Text = dr["bankname"].ToString();
                    branchname.Text = dr["branchname"].ToString();
                    ifsccode.Text = dr["ifsccode"].ToString();
                    micrcode.Text = dr["micrcode"].ToString();
                    status.Text = dr["status"].ToString();

                }
                Con.Close();
            }
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (empno.Text == "" || name.Text == "" || category.Text == "" || phoneno.Text == "" || bankacno.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into bankdetailsTable values (" + empno.Text + ",'" + name.Text + "','" + category.Text + "'," + phoneno.Text + "," + bankacno.Text + ",'" + bankname.Text + "','" + branchname.Text + "','" + ifsccode.Text + "','" + micrcode.Text + "','" + status.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bank Details Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void empno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void category_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void bankacno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void bankname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void branchname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void ifsccode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void micrcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void status_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(bankDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in bankDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in bankDGV.Rows)
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

            
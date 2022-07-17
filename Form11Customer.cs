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
    public partial class Form11Customer : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form11Customer()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from customerTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            customerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }  
        
        
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (customerid.Text == "" || CompanyName.Text == "" || address.Text == "" || city.Text == "" || state.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into customerTable values (" + customerid.Text + "," + typeid.Text + ",'" + CompanyName.Text + "','" + emailid.Text + "','" + gstno.Text + "','" + address.Text + "','" + city.Text + "','" + state.Text + "','" + statecode.Text + "'," + zipcode.Text + ",'" + igst.Text + "','" + status.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("customer Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            if (customerid.Text == "" || CompanyName.Text == "" || address.Text == "" || city.Text == "" || state.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update customerTable set  typeid =" + typeid.Text + ", companyname = '" + CompanyName.Text + "',  emailid='" + emailid.Text + "',gstno='" + gstno.Text + "',address='" + address.Text + "',city ='" + city.Text + "',state='" + state.Text + "',statecode='" + statecode.Text + "', zipcode =" + zipcode.Text + ",igst='" + igst.Text + "',status='" +status.Text + "'where customerid=" + customerid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("customer Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (customerid.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from customerTable where customerid = " + customerid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();


            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            customerid.Text = "";
            typeid.Text = "";
            CompanyName.Text = "";
            emailid.Text = "";
            gstno.Text = "";
            address.Text = "";
            city.Text = "";
            state.Text = "";
            statecode.Text = "";
            zipcode.Text = "";
            igst.Text = "";
            status.Text = "";

        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (customerid.Text == "")
            {
                MessageBox.Show("Enter Customer Id ");
            }
            else
            {
                Con.Open();
                string query = "select * from customerTable where customerid=" + customerid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    typeid.Text = dr["typeid"].ToString();
                    CompanyName.Text = dr["companyname"].ToString();
                    emailid.Text = dr["emailid"].ToString();
                    gstno.Text = dr["gstno"].ToString();
                    address.Text = dr["address"].ToString();
                    city.Text = dr["city"].ToString();
                    state.Text = dr["state"].ToString();
                    statecode.Text = dr["statecode"].ToString();
                    zipcode.Text = dr["zipcode"].ToString();
                    igst.Text = dr["igst"].ToString();
                    status.Text = dr["status"].ToString();

                }
                Con.Close();
            }
        }

        private void Form11Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void customerid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void typeid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void gstno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void city_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void state_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void zipcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void igst_KeyPress(object sender, KeyPressEventArgs e)
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
            PdfPTable pdfTable = new PdfPTable(customerDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in customerDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in customerDGV.Rows)
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


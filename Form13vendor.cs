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
    public partial class Form13vendor : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form13vendor()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from vendorTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            vendorDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (vendorid.Text == "" || name.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into vendorTable values (" + vendorid.Text + ",'" + name.Text + "','" + email.Text + "'," + phoneno.Text + ",'" + gstno.Text + "','" + address.Text + "','" + city.Text + "','" + state.Text + "'," + zipcode.Text + ",'" + status.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vendor Details Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (vendorid.Text == "" || name.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update vendorTable set  name ='" + name.Text + "',email ='" + email.Text + "',   phoneno=" + phoneno.Text + ",gstno = '" + gstno.Text + "',address ='" + address.Text + "',city='" + city.Text + "',state ='" + state.Text + "',zipcode=" + zipcode.Text + ", status =' " + status.Text + "'where vendorid=" + vendorid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (vendorid.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from vendorTable where vendorid = " + vendorid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            vendorid.Text = "";
            name.Text = "";
            email.Text = "";
            phoneno.Text = "";
            gstno.Text = "";
            address.Text = "";
            city.Text = "";
            state.Text = "";
            zipcode.Text = "";
            status.Text = "";

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (vendorid.Text == "")
            {
                MessageBox.Show("Enter Vendor Id ");
            }
            else
            {
                Con.Open();
                string query = "select * from vendorTable where vendorid=" + vendorid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    name.Text = dr["name"].ToString();
                    email.Text = dr["email"].ToString();
                    phoneno.Text = dr["phoneno"].ToString();
                    gstno.Text = dr["gstno"].ToString();
                    address.Text = dr["address"].ToString();
                    city.Text = dr["city"].ToString();
                    state.Text = dr["state"].ToString();
                    zipcode.Text = dr["zipcode"].ToString();
                    status.Text = dr["status"].ToString();

                }
                Con.Close();
            }
        }

        private void Form13vendor_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void vendorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void status_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(vendorDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in vendorDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in vendorDGV.Rows)
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

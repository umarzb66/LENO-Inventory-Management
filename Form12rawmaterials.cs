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
    public partial class Form12rawmaterials : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form12rawmaterials()
        {
            InitializeComponent();
        }

        private void Form12rawmaterials_Load(object sender, EventArgs e)
        {
            populate();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from rawmaterialsTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            rawmaterialsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (idno.Text == "" || category.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into rawmaterialsTable values (" + idno.Text + "," + code.Text + ",'" + category.Text + "','" + color.Text + "','" + size.Text + "','" + inch.Text + "','" + type.Text + "','" + status.Text + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Raw Material Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            if (idno.Text == "" || category.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update rawmaterialsTable set  code =" + code.Text + ", category = '" + category.Text + "',  color='" + color.Text + "',size='" + size.Text + "',inch='" + inch.Text + "',type ='" + type.Text + "',status='" + status.Text + "'where idno=" + idno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Raw Material Succesfully Updated");
                Con.Close();
                populate();
            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (idno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from rawmaterialsTable where idno= " + idno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();

            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (idno.Text == "")
            {
                MessageBox.Show("Enter Id No ");
            }
            else
            {
                Con.Open();
                string query = "select * from rawmaterialsTable where idno=" + idno.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    code.Text = dr["code"].ToString();
                    category.Text = dr["category"].ToString();
                    color.Text = dr["color"].ToString();
                    size.Text = dr["size"].ToString();
                    inch.Text = dr["inch"].ToString();
                    type.Text = dr["type"].ToString();
                    status.Text = dr["status"].ToString();                 

                }
                Con.Close();
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            idno.Text = "";
            code.Text = "";
            category.Text = "";
            color.Text = "";
            size.Text = "";
            inch.Text = "";
            type.Text = "";
            status.Text = "";
            
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void idno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(rawmaterialsDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in rawmaterialsDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in rawmaterialsDGV.Rows)
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

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

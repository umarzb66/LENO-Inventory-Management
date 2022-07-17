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
    public partial class Form4Workers : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");
        public Form4Workers()
        {
            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from workerTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            workerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void Form4Workers_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)

        {
            if (paidno.Text == "" || empno.Text == "" || category.Text == "" || name.Text == "" || paiddate.Text == "" || shift.Text == "" || hours.Text == "" || mode.Text == "" || paid.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Paiddate = paiddate.Value.Day.ToString() + "/" + paiddate.Value.Month.ToString() + "/" + paiddate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Paiddate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into workerTable values (" + paidno.Text + "," + empno.Text + ",'" + category.Text + "','" + name.Text + "'," + bankacno.Text + ",'" + date.ToString("MM-dd-yyyy") + "','" + shift.SelectedItem + "'," + hours.Text + ",'" + mode.SelectedItem + "'," + paid.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Paid Succesfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            if (paidno.Text == "" || empno.Text == "" || category.Text == "" || name.Text == "" || paiddate.Text == "" || shift.Text == "" || hours.Text == "" || mode.Text == "" || paid.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Paiddate = paiddate.Value.Day.ToString() + "/" + paiddate.Value.Month.ToString() + "/" + paiddate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Paiddate);
                Con.Open();
                string query = "update workerTable set  empno= " + empno.Text + ",category  ='" + category.Text + "',name ='" + name.Text + "',bankacno='" + bankacno.Text + "',paiddate ='" + date.ToString("MM-dd-yyyy") + "',shift='" + shift.SelectedItem + "',hours=" + hours.Text + ", mode =' " + mode.SelectedItem + "',paid=" + paid.Text + "where paidno=" + paidno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {


            if (paidno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from workerTable where paidno = " + paidno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();

            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            paidno.Text = "";
            empno.Text = "";
            category.Text = "";
            name.Text = "";
            bankacno.Text = "";
            paiddate.Text = "";
            shift.SelectedIndex = -1;
            hours.Text = "";
            mode.SelectedIndex= -1;
            paid.Text = "";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
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
                    bankacno.Text = dr["bankacno"].ToString();
                }
                Con.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (paidno.Text == "")
            {
                MessageBox.Show("Enter Paid No ");
            }
            else
            {
                Con.Open();
                string query = "select * from workerTable where paidno=" + paidno.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    empno.Text = dr["empno"].ToString();
                    category.Text = dr["category"].ToString();
                    name.Text = dr["name"].ToString();
                    bankacno.Text = dr["bankacno"].ToString();
                    paiddate.Text = dr["paiddate"].ToString();
                    shift.SelectedItem = dr["shift"].ToString();
                    hours.Text = dr["hours"].ToString();
                    mode.SelectedItem = dr["mode"].ToString();
                    paid.Text = dr["paid"].ToString();

                }
                Con.Close();
            }
        }

        private void paidno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void empno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void category_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void bankacno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void hours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

        }

        private void paid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(workerDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in workerDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in workerDGV.Rows)
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
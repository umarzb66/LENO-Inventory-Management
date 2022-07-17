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
    public partial class Form5Traveler : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form5Traveler()
        {
            InitializeComponent();
        }


        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form5Traveler_Load(object sender, EventArgs e)
        {
            populate();
            autocompany();
        }
        private void autocompany()
        {
            Con.Open();
            string sqlquery = "select companyname From customerTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            company.AutoCompleteMode = AutoCompleteMode.Suggest;
            company.AutoCompleteSource = AutoCompleteSource.CustomSource;
            company.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from travellerTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            travelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (travelid.Text == "" || name.Text == "" || category.Text == "" || empno.Text == "" || company.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Traveldate = traveldate.Value.Day.ToString() + "/" + traveldate.Value.Month.ToString() + "/" + traveldate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Traveldate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into travellerTable values (" + travelid.Text + ",'" + name.Text + "'," + empno.Text + ",'" + category.Text + "','" + vehicleno.Text + "'," + phoneno.Text + ",'" + date.ToString("MM-dd-yyyy") + "','" + company.Text + "','" + from.Text + "','" + to.Text + "'," + kilometer.Text + "," + cost.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Traveling Details Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {

            if (travelid.Text == "" || name.Text == "" || category.Text == "" || empno.Text == "" || company.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Traveldate = traveldate.Value.Day.ToString() + "/" + traveldate.Value.Month.ToString() + "/" + traveldate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Traveldate);
                Con.Open();
                string query = "update travellerTable set  name ='" + name.Text + "',  empno=" + empno.Text + ", category = '" + category.Text + "',vehicleno ='" + vehicleno.Text + "',  date='" + date.ToString("MM-dd-yyyy") + "',company ='" + company.Text + "',start='" + from.Text + "',stop='" + to.Text + "',kilometer=" + kilometer.Text + ",cost=" + cost.Text + " where travelid=" + travelid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (travelid.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from travellerTable where travelid = " + travelid.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            travelid.Text = "";
            name.Text = "";
            empno.Text = "";
            category.Text = "";
            vehicleno.Text = "";
            phoneno.Text = "";
            traveldate.Text = "";
            company.Text = "";
            from.Text = "";
            to.Text = "";
            kilometer.Text = "";
            cost.Text = "";
        }

        private void refersh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (travelid.Text == "")
            {
                MessageBox.Show("Enter Travel Id ");
            }
            else
            {
                Con.Open();
                string query = "select * from travellerTable where travelid=" + travelid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    name.Text = dr["name"].ToString();
                    empno.Text = dr["empno"].ToString();
                    category.Text = dr["category"].ToString();
                    vehicleno.Text = dr["vehicleno"].ToString();
                    phoneno.Text = dr["phoneno"].ToString();
                    traveldate.Text = dr["date"].ToString();
                    company.Text = dr["company"].ToString();
                    from.Text = dr["start"].ToString();
                    to.Text = dr["stop"].ToString();
                    kilometer.Text = dr["kilometer"].ToString();
                    cost.Text = dr["cost"].ToString();

                }
                Con.Close();
            }
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
                    vehicleno.Text = dr["vehicleno"].ToString();
                }
                Con.Close();

            }
        }

        private void travelid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
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

        private void phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void company_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void from_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void to_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void kilometer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(travelDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in travelDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in travelDGV.Rows)
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
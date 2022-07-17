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
    public partial class Form7Profile : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form7Profile()
        {

            InitializeComponent();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from profileTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            profileDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (empno.Text == "")
            {
                MessageBox.Show("Enter The  Employee No");
            }
            else
            {
                Con.Open();
                String query = "delete from profileTable where empno = " + empno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted Succesfully");
                Con.Close();
                populate();

            }
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (empno.Text == "")
            {
                MessageBox.Show("Enter The Acces No & Roll No");
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
                    age.Text = dr["age"].ToString();
                    category.SelectedValue = dr["category"].ToString();
                    phoneno.Text = dr["phoneno"].ToString();
                    vehicleno.Text = dr["vehicleno"].ToString();
                    address.Text = dr["address"].ToString();
                    aadharno.Text = dr["aadharno"].ToString();
                    panno.Text = dr["paneno"].ToString();
                    emailid.Text = dr["emailid"].ToString();
                    bankacno.Text = dr["bankacno"].ToString();
                    balance.Text = dr["balance"].ToString();


                }
                Con.Close();
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
           

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void Form7Profile_Load(object sender, EventArgs e)
        {

            populate();
        }

        private void profileDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            empno.Text = profileDGV.SelectedRows[0].Cells[0].Value.ToString();
            name.Text = profileDGV.SelectedRows[0].Cells[1].Value.ToString();
            age.Text = profileDGV.SelectedRows[0].Cells[2].Value.ToString();
            category.SelectedValue = profileDGV.SelectedRows[0].Cells[3].Value.ToString();
            phoneno.Text = profileDGV.SelectedRows[0].Cells[4].Value.ToString();
            vehicleno.Text = profileDGV.SelectedRows[0].Cells[5].Value.ToString();
            address.Text = profileDGV.SelectedRows[0].Cells[6].Value.ToString();
            aadharno.Text = profileDGV.SelectedRows[0].Cells[7].Value.ToString();
            panno.Text = profileDGV.SelectedRows[0].Cells[8].Value.ToString();
            emailid.Text = profileDGV.SelectedRows[0].Cells[9].Value.ToString();
            bankacno.Text = profileDGV.SelectedRows[0].Cells[10].Value.ToString();
            balance.Text = profileDGV.SelectedRows[0].Cells[11].Value.ToString();
        }

        private void guna2Button10_Click_1(object sender, EventArgs e)
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
                    age.Text = dr["age"].ToString();
                    category.Text = dr["category"].ToString();
                    phoneno.Text = dr["phoneno"].ToString();
                    vehicleno.Text = dr["vehicleno"].ToString();
                    address.Text = dr["address"].ToString();
                    aadharno.Text = dr["aadharno"].ToString();
                    panno.Text = dr["panno"].ToString();
                    emailid.Text = dr["emailid"].ToString();
                    bankacno.Text = dr["bankacno"].ToString();
                    balance.Text = dr["balance"].ToString();
                }
                Con.Close();
            }
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (empno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from profileTable where empno = " + empno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();



            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
          
            if (empno.Text == "" || name.Text == "" || age.Text == "" || category.Text == "" || phoneno.Text == "" || address.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                string query = "update profileTable set  name ='" + name.Text + "', age = " + age.Text + ", category ='" + category.SelectedItem.ToString() + "',phoneno =" + phoneno.Text + ",vehicleno ='" + vehicleno.Text + "',address ='" + address.Text + "',aadharno=" + aadharno.Text + ",panno='" + panno.Text + "', emailid =' " + emailid.Text + "',bankacno=" + bankacno.Text + ", balance = " + balance.Text + "  where empno=" + empno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            empno.Text = "";
            name.Text = "";
            age.Text = "";
            category.SelectedIndex = -1;
            phoneno.Text = "";
            vehicleno.Text = "";
            address.Text = "";
            aadharno.Text = "";
            panno.Text = "";
            emailid.Text = "";
            bankacno.Text = "";
            balance.Text = "";
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
           
            if (empno.Text == "" || name.Text == "" || age.Text == "" || category.Text == "" || phoneno.Text == "" || address.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into profileTable values (" + empno.Text + ",'" + name.Text + "'," + age.Text + ",'" + category.SelectedItem.ToString() + "'," + phoneno.Text + ",'" + vehicleno.Text + "','" + address.Text + "'," + aadharno.Text + ",'" + panno.Text + "','" + emailid.Text + "'," + bankacno.Text + "," + balance.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee  Added Succesfully");
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

        private void age_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void phoneno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void aadharno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void panno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void emailid_KeyPress(object sender, KeyPressEventArgs e)
        {
             /* if (!this.emailid.Text.Contains('@') || !this.emailid.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        private void bankacno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void balance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(profileDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in profileDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in profileDGV.Rows)
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

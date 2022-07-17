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
    public partial class Form6Bills : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form6Bills()
        {
            InitializeComponent();
        }

        private void Form6Bills_Load(object sender, EventArgs e)
        {
            populate();
            //autocustomerid();
            autovehicle();

        }
        private void autocustomerid()
        {
            Con.Open();
            string sqlquery = "select customerid From customerTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            Customerid.AutoCompleteMode = AutoCompleteMode.Suggest;
            Customerid.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Customerid.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        private void autovehicle()
        {
            Con.Open();
            string sqlquery = "select  vehicleno From profileTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            vechicleno.AutoCompleteMode = AutoCompleteMode.Suggest;
            vechicleno.AutoCompleteSource = AutoCompleteSource.CustomSource;
            vechicleno.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from billTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            billDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (billno.Text == "" || invoiceno.Text == "" || company.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Billdate = billdate.Value.Day.ToString() + "/" + billdate.Value.Month.ToString() + "/" + billdate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Billdate);
                string Notedate =notedate.Value.Day.ToString() + "/" + notedate.Value.Month.ToString() + "/" + notedate.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(Notedate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into billTable values (" + billno.Text + ",'" + invoiceno.Text + "','" + date.ToString("MM-dd-yyyy") + "'," + deliveryno.Text + ",'" + date1.ToString("MM-dd-yyyy") + "','" + Customerid.Text + "','" + company.Text + "','" + address.Text + "','" + gstno.Text + "','" + destination.Text + "','" + vechicleno.Text + "','" + goodscondition.Text + "','" + goodsdescription.Text + "'," + hsnsac.Text + "," + quantity.Text + "," + rateper.Text + "," + amount.Text + "," + sgst.Text + "," + cgst.Text + "," + totalamount.Text + ")", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill Details Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void editbtn_Click(object sender, EventArgs e)
        {
            if (billno.Text == "" || invoiceno.Text == "" || company.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Billdate = billdate.Value.Day.ToString() + "/" + billdate.Value.Month.ToString() + "/" + billdate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Billdate);
                string Notedate = notedate.Value.Day.ToString() + "/" + notedate.Value.Month.ToString() + "/" + notedate.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(Notedate);
                Con.Open();
                string query = "update billTable set  invoiceno ='" + invoiceno.Text + "', date = '" + date.ToString("MM-dd-yyyy") + "',  deliveryno=" + deliveryno.Text + ", notedate = '" + date1.ToString("MM-dd-yyyy") + "',customerid ='" + Customerid.Text + "',company ='" + company.Text + "',address='" + address.Text + "',gstno='" + gstno.Text + "',destination='" + destination.Text + "',vechicleno='" + vechicleno.Text + "', goodscondition =' " + goodscondition.Text + "', goodsdescription =' " + goodsdescription.Text + "', hsn =" + hsnsac.Text + ", quantity =" + quantity.Text + ", rateper =" + rateper.Text + ", amount =" + amount.Text + ", sgst =" + sgst.Text + ", cgst =" + cgst.Text + ", totalamount =" + totalamount.Text + "where billno=" + billno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (billno.Text == "")
            {

            }
            else
            {
                Con.Open();
                String query = "delete from billTable where billno = " + billno.Text + ";";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();
            }
        }

        private void refersh_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            billno.Text = "";
            invoiceno.Text = "";
            billdate.Text = "";
            deliveryno.Text = "";
            notedate.Text = "";
            Customerid.Text = "";
            company.Text = "";
            address.Text = "";
            gstno.Text = "";
            destination.Text = "";
            vechicleno.Text = "";
            goodscondition.Text = "";
            goodsdescription.Text = "";
            hsnsac.Text = "";
            quantity.Text = "";
            rateper.Text = "";
            amount.Text = "";
            sgst.Text = "";
            cgst.Text = "";
            totalamount.Text = "";

        }

        private void searchhere_Click(object sender, EventArgs e)
        {
            if (billno.Text == "")
            {
                MessageBox.Show("Enter Bill No ");
            }
            else
            {
                Con.Open();
                string query = "select * from billTable where billno=" + billno.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    invoiceno.Text = dr["invoiceno"].ToString();
                    billdate.Text = dr["date"].ToString();
                    deliveryno.Text = dr["deliveryno"].ToString();
                    notedate.Text = dr["notedate"].ToString();
                    Customerid.Text = dr["customerid"].ToString();
                    company.Text = dr["company"].ToString();
                    address.Text = dr["address"].ToString();
                    gstno.Text = dr["gstno"].ToString();
                    destination.Text = dr["destination"].ToString();
                    vechicleno.Text = dr["vechicleno"].ToString();
                    goodscondition.Text = dr["goodscondition"].ToString();
                    goodsdescription.Text = dr["goodsdescription"].ToString();
                    hsnsac.Text = dr["hsn"].ToString();
                    quantity.Text = dr["quantity"].ToString();
                    rateper.Text = dr["rateper"].ToString();
                    amount.Text = dr["amount"].ToString();
                    sgst.Text = dr["sgst"].ToString();
                    cgst.Text = dr["cgst"].ToString();
                    totalamount.Text = dr["totalamount"].ToString();
                }
                Con.Close();
            }
        }

        private void searchbtn_Click(object sender, EventArgs e)
        {
            if (Customerid.Text == "")
            {
                MessageBox.Show("Enter Customer Id");
            }
            else
            {
                Con.Open();
                string query = "select * from customerTable where customerid=" + Customerid.Text + "";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    company.Text = dr["companyname"].ToString();
                    address.Text = dr["address"].ToString();
                    gstno.Text = dr["gstno"].ToString();
                    destination.Text = dr["state"].ToString();

                }
                Con.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (quantity.Text == ""|| rateper.Text == "" || sgst.Text == "" || cgst.Text == ""  )
            {
                MessageBox.Show("Missing information");

            }
            else
            {
                int num1, num2, res, per1, per2, per3, cg1, cg2, cg3, tot1, tot2, tot3, tot4;
                num1 = Convert.ToInt32(quantity.Text);
                num2 = Convert.ToInt32(rateper.Text);
                res = num1 * num2;
                amount.Text = Convert.ToString(res);

                per1 = Convert.ToInt32(res);
                per2 = Convert.ToInt32(sgst.Text);
                per3 = per1 * per2 / 100;
                sgst.Text = Convert.ToString(per3);

                cg1 = Convert.ToInt32(res);
                cg2 = Convert.ToInt32(cgst.Text);
                cg3 = per1 * per2 / 100;
                cgst.Text = Convert.ToString(cg3);

                tot1 = Convert.ToInt32(amount.Text);
                tot2 = Convert.ToInt32(sgst.Text);
                tot3 = Convert.ToInt32(cgst.Text);
                tot4 = tot1 + tot2 + tot3;
                totalamount.Text = Convert.ToString(tot4);
            }
        }

        private void billno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void deliveryno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void Customerid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void company_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void destination_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
                e.Handled = true;
        }

        private void hsnsac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void rateper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void sgst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void cgst_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void totalamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void invoiceno_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(billDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in billDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in billDGV.Rows)
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
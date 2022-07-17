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
    public partial class Form3Purchase : Form
    {
        SqlConnection Con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PC\\Documents\\leno.mdf;Integrated Security=True;Connect Timeout=30");

        public Form3Purchase()
        {
            InitializeComponent();
        }
        private void pass()
        {
            
        }
        private void Form3Purchase_Load(object sender, EventArgs e)
        {
            populate();
            autocategory();
            pass();
        }
        public void populate()
        {
            Con.Open();
            string query = "select * from purchaseTable";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            purchaseDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void autocategory()
        {
            Con.Open();
            string sqlquery = "select category From rawmaterialsTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            category.AutoCompleteMode = AutoCompleteMode.Suggest;
            category.AutoCompleteSource = AutoCompleteSource.CustomSource;
            category.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        private void autobankid()
        {
            Con.Open();
            string sqlquery = "selec bankacno From bankdetailsTable";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, Con);
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            AutoCompleteStringCollection autotext = new AutoCompleteStringCollection();
            while (sdr.Read())
            {
                autotext.Add(sdr.GetString(0));
            }
            bankid.AutoCompleteMode = AutoCompleteMode.Suggest;
            bankid.AutoCompleteSource = AutoCompleteSource.CustomSource;
            bankid.AutoCompleteCustomSource = autotext;
            Con.Close();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (invoiceno.Text == "" || category.Text == "" || quantity.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Purchasedate = purchasedate.Value.Day.ToString() + "/" + purchasedate.Value.Month.ToString() + "/" + purchasedate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Purchasedate);
                string Checkdate = checkdate.Value.Day.ToString() + "/" + checkdate.Value.Month.ToString() + "/" + checkdate.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(Checkdate);
                Con.Open();
                SqlCommand cmd = new SqlCommand("insert into purchaseTable values ('" + invoiceno.Text + "'," + vendorid.Text + ",'" + gstid.Text + "','" + date.ToString("MM-dd-yyyy") + "','" + category.Text + "'," + hsn.Text + "," + quantity.Text + "," + perprice.Text + "," + totalprice.Text + "," + disc.Text + "," + totalamount.Text + "," + currentbalance.Text + "," + balance.Text + "," + bankid.Text + "," + checkno.Text + ",'" + date1.ToString("MM-dd-yyyy") + "')", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Purchase Details Added Succesfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

            if (invoiceno.Text == "" || category.Text == "" || quantity.Text == "")

            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                string Purchasedate = purchasedate.Value.Day.ToString() + "/" + purchasedate.Value.Month.ToString() + "/" + purchasedate.Value.Year.ToString();
                DateTime date = Convert.ToDateTime(Purchasedate);
                string Checkdate = checkdate.Value.Day.ToString() + "/" + checkdate.Value.Month.ToString() + "/" + checkdate.Value.Year.ToString();
                DateTime date1 = Convert.ToDateTime(Checkdate);
                Con.Open();
                string query = "update purchaseTable set  vendorid=" + vendorid.Text + ", gstid='" + gstid.Text + "', purchasedate ='" + date.ToString("MM-dd-yyyy") + "', category = '" + category.Text + "', hsn= " + hsn.Text + ",quantity =" + quantity.Text + ",perprice=" + perprice.Text + ", totalprice= '" + totalprice.Text + "' ,disc =" + disc.Text + ",totalamount=" + totalamount.Text + ",currentbalance="+currentbalance.Text+", balance= " + balance.Text + ", bankacno= " + bankid.Text + ", checkno= " + checkno.Text + ",date='" + date1.ToString("MM-dd-yyyy") + "' where invoiceno='" + invoiceno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Purchase Details  Succesfully Updated");
                Con.Close();
                populate();

            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

            if (invoiceno.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                String query = "delete from purchaseTable where invoiceno= '" + invoiceno.Text + "';";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted  Sucessfully");
                Con.Close();
                populate();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            vendorid.Text = "";
            invoiceno.Text = "";
            purchasedate.Text = "";
            category.Text = "";
            gstid.Text = "";
            quantity.Text = "";
            perprice.Text = "";
            disc.Text = "";
            totalamount.Text = "";
            currentbalance.Text = "";
            balance.Text = ""; 
            hsn.Text = "";
            bankid.Text = "";
            checkno.Text = "";
            checkdate.Text = "";
            totalprice.Text = "";
        
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (invoiceno.Text == "")
            {
                MessageBox.Show("Enter invoice No ");
            }
            else
            {
                Con.Open();
                string query = "select * from purchaseTable where invoiceno='" + invoiceno.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    
                    vendorid.Text = dr["vendorid"].ToString();
                    gstid.Text = dr["gstid"].ToString();
                    quantity.Text = dr["quantity"].ToString();
                    category.Text = dr["category"].ToString();
                    purchasedate.Value = Convert.ToDateTime(dr["purchasedate"].ToString());
                    perprice.Text = dr["perprice"].ToString();
                    totalprice.Text = dr["perprice"].ToString(); 
                    disc.Text = dr["disc"].ToString();
                    totalamount.Text = dr["totalamount"].ToString();
                    currentbalance.Text = dr["currentbalance"].ToString();
                    balance.Text = dr["balance"].ToString();
                    hsn.Text = dr["hsn"].ToString();
                    bankid.Text = dr["bankacno"].ToString();
                    checkno.Text = dr["checkno"].ToString();
                    checkdate.Value = Convert.ToDateTime(dr["date"].ToString());
                   
                  
                }
                Con.Close();
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (vendorid.Text == "")
            {
                MessageBox.Show("Enter Vendor id ");
            }
            else
            {
                Con.Open();
                string query = "select * from vendorTable where vendorid='" + vendorid.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {

                    vendorid.Text = dr["vendorid"].ToString();
                    gstid.Text = dr["gstno"].ToString();              

                }
                Con.Close();
            }
        }
     
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int num1, num2, res, per1, per2, per3,tot1,tot2,tot3;
            num1 = Convert.ToInt32(quantity.Text);
            num2 = Convert.ToInt32(perprice.Text);
            res = num1 * num2;
            totalprice.Text = Convert.ToString(res);
            per1 = Convert.ToInt32(res);
            per2 = Convert.ToInt32(disc.Text);
            per3 = per1 * per2 / 100;
            disc.Text = Convert.ToString(per3);
            tot1 = Convert.ToInt32(totalprice.Text);
            tot2 = Convert.ToInt32(disc.Text);
            tot3 = tot1 - tot2 ;
            totalamount.Text = Convert.ToString(tot3);

        }

        private void vendorid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void gstid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
                e.Handled = true;
        }

        private void hsn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void perprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void totalprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void disc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void totalamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void currentbalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void balance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void bankid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void checkno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(purchaseDGV.ColumnCount);
            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            string fileName = string.Empty;


            //Adding Header row
            foreach (DataGridViewColumn column in purchaseDGV.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in purchaseDGV.Rows)
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

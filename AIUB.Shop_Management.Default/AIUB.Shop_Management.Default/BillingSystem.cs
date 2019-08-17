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
using iTextSharp.text; //for ItextSharp
using iTextSharp.text.pdf; //for ItextSharp ->> PDF
using System.IO; //for Input and Output

namespace AIUB.Shop_Management.Default
{
    public partial class BillingSystem : Form
    {
        public BillingSystem()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        double totalCost = 0;
        double amount;

        private void Invoice()
        {
            SqlConnection con = new SqlConnection("Data Source=NAZIBMAHFUZ;Initial Catalog=SuperShopManagementSystem;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select max(Invoice)+1 from Sells", con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    txtInvoice.Text = dr[0].ToString();
                    if (txtInvoice.Text == "")
                    {
                        txtInvoice.Text = "100";
                    }
                }
            }
            else
            {
                txtInvoice.Text = "1001";
            }
            con.Close();
        }

        private void txtProductId_TextChanged(object sender, EventArgs e)
        {


            try
            {
                SqlConnection con = new SqlConnection("Data Source=NAZIBMAHFUZ;Initial Catalog=SuperShopManagementSystem;Integrated Security=True");
                con.Open();
                string query = "select Name,SellsPrice,Unit from Product where ProductId='" + txtProductId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                

                if (dt.Rows.Count == 1)
                {
                    txtPName.Text = dt.Rows[0]["Name"].ToString();
                    txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                    txtUnitPrice.Text = dt.Rows[0]["SellsPrice"].ToString();


                }
                

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtQuentity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuentity.Text != "")
            {
                try
                {
                    double qnty = Convert.ToDouble(txtQuentity.Text);

                    double price = Convert.ToDouble(txtUnitPrice.Text);

                    //Calculate Amount in a Product
                    amount = qnty * price;
                    txtAmount.Text = Convert.ToString(amount);

                    totalCost = double.Parse(txtTotal.Text);
                    totalCost = totalCost + amount;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }



        private void ItemTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //authentication
            if (txtProductId.Text == "")
            {
                MessageBox.Show("Invalid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtQuentity.Text == "")
            {
                MessageBox.Show("Please add Product Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txtPName.Text == "")
            {
                MessageBox.Show("Product Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Add Item In Data Table
            addData(txtInvoice.Text, txtProductId.Text, txtPName.Text, txtUnitPrice.Text, txtQuentity.Text, txtUnit.Text, txtAmount.Text);

            //string query = "insert into Sells_Details(Invoice,ProductId,Name,Unit,UnitPrice,Qnty,Amount) "
            //    + "values(" + txtInvoice.Text + ",'" + txtProductId.Text + "','" + txtPName.Text + "','" + txtUnit.Text + "'," + txtUnitPrice.Text + "," + txtQuentity.Text + "," + txtAmount.Text + ")";
            //DBConnection.ExecuteQuery(query);
            //MessageBox.Show("Item Added", "Cong !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            //Clear All TextBox regarding Product Info
            if(txtTotal.Text!="")
                txtTotal.Text = totalCost.ToString();
            

            txtProductId.Text = "";
            txtPName.Text = "";
            txtUnit.Text = "";
            txtUnitPrice.Text = "";
            txtQuentity.Text = "";
            txtAmount.Text = "";
            txtProductId.Focus();



        }

        private void addData(string inv, string id, string name, string unitprice, string quentity, string unit, string amount)
        {
            String[] row = { inv,id, name, unitprice, quentity, unit, amount };
            ItemTable.Rows.Add(row);


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(txtDiscount.Text != "")
            {
                
             try 
	            {	        
		            double discount = double.Parse(txtDiscount.Text);
                    discount = ((100 - discount) / 100 * totalCost);
                    txtNetAmount.Text = discount.ToString();

                    //Savings Amount
                    double t = double.Parse(txtTotal.Text);
                    double na = double.Parse(txtNetAmount.Text);
                    double savings = t - na;
                    txtSavings.Text = savings.ToString();
	            }
	            catch (Exception ex)
	            {
		
		            MessageBox.Show(ex.Message);
	            }
            }
            //Discount 
            
            }

        private void txtSavings_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGivenAmount_TextChanged(object sender, EventArgs e)
        {
            if(txtGivenAmount.Text !="")
            {
                try
                {
                    double given = double.Parse(txtGivenAmount.Text);
                    double na = double.Parse(txtNetAmount.Text);
                    double returnamount = given - na;
                    txtReturn.Text = returnamount.ToString();
                    txtGivenAmount.Text = given.ToString();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }


       
        //Cancel Transaction
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Cancel the whole Transaction ?", "Confarmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
            }
        }

        public void exportPdf(DataGridView dgv, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgv.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //adding header

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            //add data row

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(txtNetAmount.Text=="")
            {
                MessageBox.Show("Invalid Transaction", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Invoice(); //Call Invoice Method
            try
            {
                ////additem into database from ItemTable(dataGrideView)
                for (int i = 0; i < ItemTable.Rows.Count ; i++)
                {
                    string queryItemAdd = "insert into Sells_Details(Invoice,ProductId,Name,UnitPrice,Qnty,Unit,Amount) "
                        + "values('"+ItemTable.Rows[i].Cells[0].Value+"','"+ItemTable.Rows[i].Cells[1].Value+"','"+ItemTable.Rows[i].Cells[2].Value+"','"+ItemTable.Rows[i].Cells[3].Value+"','"+ItemTable.Rows[i].Cells[4].Value+"','"+ItemTable.Rows[i].Cells[5].Value+"','"+ItemTable.Rows[i].Cells[6].Value+"')";
                    DBConnection.ExecuteQuery(queryItemAdd);
                   
                }
                //Insert Data Into Sells Table
                string query = "insert into Sells(CustomerId,SellsDate,TotalPrice,Discount,NetAmount) "
                    + "values ('" + txtCustomerId.Text + "','" + dtpTranscDate.Text + "'," + txtTotal.Text + "," + txtDiscount.Text + "," + txtNetAmount.Text + ")";
                DBConnection.ExecuteQuery(query);

                //Update Customer Point If any Registered Customer 

                string query1 = "Update Customer set Point='" + txtTotalPoint.Text + "' where CustomerId='" + txtCustomerId.Text + "'";
                DBConnection.ExecuteQuery(query1);
                exportPdf(ItemTable, "Invoice");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ItemTable.Rows.Clear();
            txtDiscount.Text = txtGivenAmount.Text = txtReturn.Text = txtSavings.Text = txtNetAmount.Text = "";
            txtCustomerId.Text = txtConvertedPoint.Text = txtTotalPoint.Text = "";
            txtTotal.Text = "0.00".ToString();
            drpPaymentType.ResetText();
            
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //press enter to go to the password
            {
                txtQuentity.Focus();
            }
        }

        private void txtQuentity_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnAdd.PerformClick(); //Fire Add Button Click Event;
            }
        }

        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtProductId.Focus();
            }
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Invoice();
            
        }

        private void BillingSystem_Load(object sender, EventArgs e)
        {
            Invoice();
            
        }

        private void txtNetAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if(txtTotal.Text!="")
            {
                pointCalculation();
            }
            
        }

        private void pointCalculation()
        {
            double point;
            double taka = Convert.ToDouble(txtTotal.Text);
            point = ((1 * taka) / 1000);
            double totalpoint = 0.0;
            totalpoint = point + totalpoint; 

            txtConvertedPoint.Text = point.ToString();
            txtTotalPoint.Text = totalpoint.ToString();
        }

        private void txtConvertedPoint_TextChanged(object sender, EventArgs e)
        {
            //pointCalculation();
        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            
            if(txtCustomerId.Text!=null)
            {
                try
                {
                    string query = "select Point from Customer  where CustomerId='" + txtCustomerId.Text + "'";
                    DataTable dt = DBConnection.GetDataTable(query);

                    if(dt.Rows.Count ==1)
                    {
                        
                        txtTotalPoint.Text = dt.Rows[0]["Point"].ToString();
                        double tp = Convert.ToDouble(txtTotalPoint.Text);
                        double p = Convert.ToDouble(txtConvertedPoint.Text);
                        tp = tp + p;
                        txtTotalPoint.Text = tp.ToString();
                    }
                    else
                    {
                        pointCalculation();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

            }
            
        }

        private void ItemTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                string id = ItemTable.Rows[e.RowIndex].Cells[0].Value.ToString();

                try
                {
                    string query = "select * from Sells_Details where ProductId='"+id+"' and Invoice="+txtInvoice.Text+"";
                    DataTable dt = DBConnection.GetDataTable(query);

                    if(dt.Rows.Count==1)
                    {
                        txtProductId.Text = dt.Rows[0]["ProductId"].ToString();
                        txtPName.Text = dt.Rows[0]["Name"].ToString();
                        txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                        txtUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                        txtQuentity.Text = dt.Rows[0]["Qnty"].ToString();
                        txtAmount.Text = dt.Rows[0]["Amount"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Product Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                txtGivenAmount.Focus();
            }
        }

        private void txtGivenAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                drpPaymentType.Focus();
            }
        }

    }
}

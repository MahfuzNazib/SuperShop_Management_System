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


        private void txtProductId_TextChanged(object sender, EventArgs e)
        {


            try
            {
                SqlConnection con = new SqlConnection("Data Source=NAZIBMAHFUZ;Initial Catalog=SuperShopManagementSystem;Integrated Security=True");
                con.Open();
                string query = "select Name,SellsPrice,Unit from Product_Brand,Product where Product_Brand.ProductId='" + txtProductId.Text + "' and Product.ProductId='" + txtProductId.Text + "'";
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
            addData(txtProductId.Text, txtPName.Text, txtUnitPrice.Text, txtQuentity.Text, txtUnit.Text, txtAmount.Text);

            MessageBox.Show("Congratulations", "Item Added Done !", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            //Clear All TextBox regarding Product Info
            txtTotal.Text = totalCost.ToString();

            txtProductId.Text = "";
            txtPName.Text = "";
            txtUnit.Text = "";
            txtUnitPrice.Text = "";
            txtQuentity.Text = "";
            txtAmount.Text = "";



        }

        private void addData(string id, string name, string unitprice, string quentity, string unit, string amount)
        {
            String[] row = { id, name, unitprice, quentity, unit, amount };
            ItemTable.Rows.Add(row);


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            //Discount 
            double discount = double.Parse(txtDiscount.Text);
            discount = ((100 - discount) / 100 * totalCost);
            txtNetAmount.Text = discount.ToString();

            //Savings Amount
            double t = double.Parse(txtTotal.Text);
            double na = double.Parse(txtNetAmount.Text);
            double savings = t - na;
            txtSavings.Text = savings.ToString();


        }

        private void txtSavings_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGivenAmount_TextChanged(object sender, EventArgs e)
        {
            double given = double.Parse(txtGivenAmount.Text);
            double na = double.Parse(txtNetAmount.Text);
            double returnamount = given - na;
            txtReturn.Text = returnamount.ToString();
            txtGivenAmount.Text = given.ToString();
        }


        //Clear Function

        private void Init()
        {
            Close();
        }

        //Cancel Transaction
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to Cancel the whole Transaction ?", "Confarmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Init();
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
            //if (MessageBox.Show("Printing is under Construction", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    Init();
            //}
            exportPdf(ItemTable, "Invoice");
        }


    }
}

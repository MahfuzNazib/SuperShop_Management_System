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
    public partial class ProductList : Form
    {
        public ProductList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Init();
            
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = true;
           

        }

        private void Init()
        {
            txtBrand.Text = txtBuyerName.Text = txtID.Text = txtName.Text = txtType.Text = "";
            txtBrand.ReadOnly = txtBuyerName.ReadOnly = txtID.ReadOnly = txtName.ReadOnly = txtType.ReadOnly = false; 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            string query = "update ProductList set [Type]='"+txtType.Text+"',Brand='"+txtBrand.Text+"',Name='"+txtName.Text+"',BuyerName='" + txtBuyerName.Text + "' where ProductId='" + txtID.Text + "'";
            DBConnection.ExecuteQuery(query);
            MessageBox.Show("Buyers " + txtBuyerName.Text + " Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProductList();
        }

        private void LoadProductList()
        {
            string query = "Select * from ProductList";
            DataTable dt = DBConnection.GetDataTable(query);
            dgvProductList.DataSource = dt;
            dgvProductList.Refresh();
        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            LoadProductList();
            Init();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "delete from ProductList  where ProductId='" + txtID.Text + "'";


                if (MessageBox.Show("Are you sure?", "confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DBConnection.ExecuteQuery(query);
                    MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LoadProductList();
                Init();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProductList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBrand.ReadOnly = false;
            txtName.ReadOnly = false;
            txtType.ReadOnly = false;
            txtID.ReadOnly = false;

            if(e.RowIndex>=0)
            {
                string id = dgvProductList.Rows[e.RowIndex].Cells[3].Value.ToString();
                try
                {
                    string query = "select * from ProductList where ProductId='"+id+"'";
                    DataTable dt = DBConnection.GetDataTable(query);

                    if (dt.Rows.Count == 1)
                    {
                        txtType.Text = dt.Rows[0]["Type"].ToString();
                        txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtID.Text = dt.Rows[0]["ProductId"].ToString();
                        txtBuyerName.Text = dt.Rows[0]["BuyerName"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "insert into ProductList([Type],Brand,Name,ProductId,BuyerName) "
               + "values ('" + txtType.Text + "','" + txtBrand.Text + "','" + txtName.Text + "','" + txtID.Text + "','" + txtBuyerName.Text + "')";
            DBConnection.ExecuteQuery(query);
            MessageBox.Show("Product " + txtName.Text + " Successfully added", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadProductList();
            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmboSearchBy.SelectedItem == "Type")
            {
                string query = "select * from ProductList where Type = '" + txtSerach.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvProductList.DataSource = dt;
                dgvProductList.Refresh();
            }

            else if ((cmboSearchBy.SelectedItem).ToString() == "Brand")
            {
                string query = "select * from ProductList where Brand = '" + txtSerach.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvProductList.DataSource = dt;
                dgvProductList.Refresh();
            }
            else if (cmboSearchBy.SelectedItem == "Name")
            {
                string query = "select * from ProductList where Name = '" + txtSerach.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvProductList.DataSource = dt;
                dgvProductList.Refresh();
            }
            else if (cmboSearchBy.SelectedItem == "ProductId")
            {
                string query = "select * from ProductList where ProductId = '" + txtSerach.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvProductList.DataSource = dt;
                dgvProductList.Refresh();
            }
            else if (cmboSearchBy.SelectedItem == "BuyerName")
            {
                string query = "select * from ProductList where BuyerName = '" + txtSerach.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvProductList.DataSource = dt;
                dgvProductList.Refresh();
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void cmboSearchBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string q = "select (select SUM(PurchaseQuentity) from Purchase where ProductId='" + txtID.Text + "')-"
                            + "(select SUM(Qnty) from Sells_Details where ProductId='" + txtID.Text + "') as Available"; 
            DataTable dt=DBConnection.GetDataTable(q);

            txtAvailable.Text = dt.Rows[0]["Available"].ToString();
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


        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            exportPdf(dgvProductList, "Product List Pdf");
        }
    }
}

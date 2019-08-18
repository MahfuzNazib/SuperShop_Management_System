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

namespace AIUB.Shop_Management.Default
{
    public partial class Purches : Form
    {
        private int slnoCount;

        public Purches()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Hide();
        }

        private void Init()
        {
            txtType.Text = txtBuyerName.Text = txtBrand.Text = txtAmount.Text = txtBPrice.Text = txtBrand.Text = txtSearch.text = txtName.Text = txtProductId.Text = txtSPrice.Text = txtType.Text = txtUnit.Text = txtInvestment.Text= "" ;

        }

        private void ButtonControl()
        {
            btnSave.Visible=false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            //btnDelete.Visible = true;
        }

        private void LoadDetails()
        {
            try
            {
                string query = "select * from Purchase";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvPurchase.DataSource = dt;
                dgvPurchase.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Search()
        {
            
            try
            {
                    string query = "select * from Purchase where ProductId ='" + txtSearch.text + "'";
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvPurchase.DataSource = dt;
                    dgvPurchase.Refresh();
                    //MessageBox.Show("Invalid Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bILLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.Show();
            this.Hide();
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductInfo a = new ProductInfo();
            a.Show();
            this.Hide();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Init(); //Clear all Data

            btnSave.Visible = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            //btnDelete.Visible = false;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtProductId.Enabled)
            {
                try
                {
                    

                    string query = "insert into ProductList ([Type],Brand,Name,ProductId,BuyerName) "+
                        "values('" + txtType.Text + "','" + txtBrand.Text + "','" + txtName.Text + "','" + txtProductId.Text + "','" + txtBuyerName.Text+ "')";
                    DBConnection.ExecuteQuery(query);

                    query = "insert into Purchase(ProductId,PurchaseDate,UnitPrice,SellsPrice,PurchaseQuentity,Unit,TotalCost) "
                    + "values ('" + txtProductId.Text + "','" + dtpPurchaseDate.Text + "'," + txtBPrice.Text + "," + txtSPrice.Text + "," + txtAmount.Text + ",'" + txtUnit.Text + "','" + txtInvestment.Text + "')";
                    DBConnection.ExecuteQuery(query);
                    MessageBox.Show("Product : " + txtName.Text + " added Done", "Cong.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    string query = "insert into Purchase(ProductId,PurchaseDate,UnitPrice,SellsPrice,PurchaseQuentity,Unit,TotalCost) "
                    + "values ('" + txtProductId.Text + "','" + dtpPurchaseDate.Text + "'," + txtBPrice.Text + "," + txtSPrice.Text + "," + txtAmount.Text + ",'" + txtUnit.Text + "','" + txtInvestment.Text + "')";
                    DBConnection.ExecuteQuery(query);
                    MessageBox.Show("Product : " + txtName.Text + " added Done", "Cong.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void Purches_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void dgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvPurchase.Rows[e.RowIndex].Cells[1].Value.ToString();
                string slno = dgvPurchase.Rows[e.RowIndex].Cells[0].Value.ToString();
                slnoCount = Int32.Parse(slno);
                try
                {

                    string query = "select [Type],Brand,Name,BuyerName,Purchase.ProductId,SlNo,SellsPrice,PurchaseQuentity,PurchaseDate,UnitPrice,Unit from ProductList,Purchase where ProductList.ProductId='" + id + "' and Purchase.SlNo='" + slno + "'";
                    DataTable dt = DBConnection.GetDataTable(query);

                    if (dt.Rows.Count == 1)
                    {
                        txtType.Text = dt.Rows[0]["Type"].ToString();
                        txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtProductId.Text = dt.Rows[0]["ProductId"].ToString();
                        txtBPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                        txtSPrice.Text = dt.Rows[0]["SellsPrice"].ToString();
                        txtAmount.Text = dt.Rows[0]["PurchaseQuentity"].ToString();
                        txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                        dtpPurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
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
            btnControl();
            txtName.Enabled = txtBrand.Enabled = txtProductId.Enabled = txtBuyerName.Enabled = false;
            txtType.ReadOnly = true;
        }
        public void btnControl()
        {
            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
        }
        private void btnLSearch_Click(object sender, EventArgs e)
        {
            Search();
            Init();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
            {
                MessageBox.Show("Please Select a Product First", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            try
            {
                string query = "update Purchase set "+
                    "UnitPrice="+txtBPrice.Text+",SellsPrice="+txtSPrice.Text+","
                    +"PurchaseQuentity="+txtAmount.Text+",Unit='"+txtUnit.Text+" '"
                    + " where ProductId='" + txtProductId.Text + "' and SlNo= " + slnoCount + "";
                DBConnection.ExecuteQuery(query);
                MessageBox.Show("Successfully Updated", "Cong.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDetails();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //
            
        }

        private void txtAmount_OnValueChanged(object sender, EventArgs e)
        {
            if(txtBPrice.Text!=null)
            {
                try
                {
                    double bprice = Convert.ToDouble(txtBPrice.Text);
                    double qnty = Convert.ToDouble(txtAmount.Text);
                    double invst = bprice * qnty;
                    txtInvestment.Text = invst.ToString();
                    txtBPrice.Text = bprice.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                txtBPrice.Text = "";
            }
            
        }

        private void txtType_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                txtBrand.Focus();
            }
        }

        private void txtBrand_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txtBrand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtProductId.Focus();
            }
        }

        private void txtProductId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBuyerName.Focus();
            }
        }

        private void txtBPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSPrice.Focus();
            }
        }

        private void txtSPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAmount.Focus();
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnit.Focus();
            }
        }

        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpPurchaseDate.Focus();
            }
        }

        private void txtSearch_OnTextChange(object sender, EventArgs e)
        {
            btnControl();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            Init();
            txtName.Enabled = txtBrand.Enabled = txtProductId.Enabled = txtBuyerName.Enabled = true;
            txtType.ReadOnly = false;
            LoadDetails();
        }

        private void txtBuyerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBPrice.Focus();
            }
        }

        private void txtBuyerName_OnValueChanged(object sender, EventArgs e)
        {

        }

    }
}

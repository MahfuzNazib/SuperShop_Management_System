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
            txtType.Text = txtBrand.Text = txtAmount.Text = txtBPrice.Text = txtBrand.Text = txtSearch.text = txtName.Text = txtProductId.Text = txtSPrice.Text = txtType.Text = txtUnit.Text = txtInvestment.Text="";

        }

        private void ButtonControl()
        {
            btnSave.Visible=false;
            btnAdd.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }

        private void LoadDetails()
        {
            try
            {
                string query = "select * from Product";
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
                if(drpSearch.selectedValue=="Type")
                {
                    string query = "select * from Product where Product_Type ='" + txtSearch.text + "'";
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvPurchase.DataSource = dt;
                    dgvPurchase.Refresh();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("This Type of Product does not exist", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }

                else if(drpSearch.selectedValue=="Name")
                {
                    string query = "select * from Product where Name ='" + txtSearch.text + "'";
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvPurchase.DataSource = dt;
                    dgvPurchase.Refresh();

                    if (dt.Rows.Count != 1)
                    {
                        MessageBox.Show("Invalid Product Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (drpSearch.selectedValue == "Brand")
                {
                    string query = "select * from Product where Brand ='" + txtSearch.text + "'";
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvPurchase.DataSource = dt;
                    dgvPurchase.Refresh();

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Invalid Product Brand", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    string query = "select * from Product where ProductId ='" + txtSearch.text + "'";
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvPurchase.DataSource = dt;
                    dgvPurchase.Refresh();

                    if (dt.Rows.Count == 1)
                    {
                        txtType.Text = dt.Rows[0]["Product_Type"].ToString();
                        txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtProductId.Text = dt.Rows[0]["ProductId"].ToString();
                        txtBPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                        txtSPrice.Text = dt.Rows[0]["SellsPrice"].ToString();
                        txtAmount.Text = dt.Rows[0]["PurchaseQuentity"].ToString();
                        txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                        dtpPurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
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
            Init(); //Clear all Data

            btnSave.Visible = true;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into Product(Product_Type,Brand,Name,ProductId,PurchaseDate,UnitPrice,SellsPrice,PurchaseQuentity,Unit,TotalCost) "
                + "values ('" + txtType.Text + "','" + txtBrand.Text + "','" + txtName.Text + "','" + txtProductId.Text + "','" + dtpPurchaseDate.Text + "'," + txtBPrice.Text + "," + txtSPrice.Text + "," + txtAmount.Text + ",'" + txtUnit.Text + "','"+txtInvestment.Text+"')";
                DBConnection.ExecuteQuery(query);
                MessageBox.Show("Product : " + txtName.Text + " added Done", "Cong.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDetails();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                string id = dgvPurchase.Rows[e.RowIndex].Cells[3].Value.ToString();
                try
                {

                    string query = "select * from Product where ProductId ='"+id+"'";
                    DataTable dt = DBConnection.GetDataTable(query);

                    if (dt.Rows.Count == 1)
                    {
                        txtType.Text = dt.Rows[0]["Product_Type"].ToString();
                        txtBrand.Text = dt.Rows[0]["Brand"].ToString();
                        txtName.Text = dt.Rows[0]["Name"].ToString();
                        txtProductId.Text = dt.Rows[0]["ProductId"].ToString();
                        txtBPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                        txtSPrice.Text = dt.Rows[0]["SellsPrice"].ToString();
                        txtAmount.Text = dt.Rows[0]["PurchaseQuentity"].ToString();
                        txtUnit.Text = dt.Rows[0]["Unit"].ToString();
                        dtpPurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
                        
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
        }
        public void btnControl()
        {
            btnAdd.Visible = true;
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
        }
        private void btnLSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
            {
                MessageBox.Show("Please Select a Product First", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            try
            {
                
                string query = "update Product set Product_Type='"+txtType.Text+"',Brand='"+txtBrand.Text+"',Name='"+txtName.Text+"',"
                    +"PurchaseDate='"+dtpPurchaseDate.Text+"',UnitPrice="+txtBPrice.Text+",SellsPrice="+txtSPrice.Text+","
                    +"PurchaseQuentity="+txtAmount.Text+",Unit='"+txtUnit.Text+" '"
                    +" where ProductId='"+txtProductId.Text+"'";
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
            if (txtProductId.Text == "")
            {
                MessageBox.Show("Please Select a Product First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                string query = "delete from Product where ProductId='" + txtProductId.Text + "'";
                DBConnection.ExecuteQuery(query);
                MessageBox.Show("Successfully Deleted", "Cong.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDetails();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
                txtBPrice.Focus();
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


    }
}

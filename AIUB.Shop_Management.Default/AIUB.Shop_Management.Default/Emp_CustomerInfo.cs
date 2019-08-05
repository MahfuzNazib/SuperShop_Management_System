using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIUB.Shop_Management.Default
{
    public partial class Emp_CustomerInfo : Form
    {
        public Emp_CustomerInfo()
        {
            InitializeComponent();
        }

        public void LoadDetails()
        {
            if (txtSearch.text == "")
            {
                try
                {
                    string query = "select * from Customer";
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvCustomerInfo.DataSource = dt;
                    dgvCustomerInfo.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(txtSearch.text!=null)
            {
                try
                {
                    string query = "select * from Customer where CustomerId="+txtSearch.text;
                    DataTable dt = DBConnection.GetDataTable(query);
                    dgvCustomerInfo.DataSource = dt;
                    dgvCustomerInfo.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

               
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.text=="")
            {
                MessageBox.Show("Please Enter a Valid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDetails();
        }

        private void Emp_CustomerInfo_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            txtSearch.text = "";
            LoadDetails();
        }


       
    }
}

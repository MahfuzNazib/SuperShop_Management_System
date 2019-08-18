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
    
    public partial class AddCustomer : Form
    {
        //public DBConnection con;
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCustomerId.Text = txtCustomerName.Text = txtCustomerContact.Text  = dateCustomerJoining.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into Customer(CustomerId,CustomerName,Contact,JoiningDate,Point) "
                    +"values('"+txtCustomerId.Text+"','"+txtCustomerName.Text+"','"+txtCustomerContact.Text+"','"+dateCustomerJoining.Text+"','"+0+"')";
                DBConnection.ExecuteQuery(query);
                MessageBox.Show("Customer Addaed Done ", "Add New Customer", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            if(txtCustomerId.Text=="")
            {
                MessageBox.Show("ID Must be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(txtCustomerName.Text=="")
            {
                MessageBox.Show("Name Must be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtCustomerContact.Text == "")
            {
                MessageBox.Show("Contact Must be Filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            txtCustomerId.Text = txtCustomerName.Text = txtCustomerContact.Text = dateCustomerJoining.Text = "";
        }

        private void txtCustomerContact_TextChanged(object sender, EventArgs e)
        {
            txtCustomerId.Text = txtCustomerContact.Text;


        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            txtCustomerName.Focus();
        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

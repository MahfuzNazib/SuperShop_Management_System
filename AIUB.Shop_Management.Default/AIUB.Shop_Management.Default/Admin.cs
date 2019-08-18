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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

       
        private void btnReport_Click(object sender, EventArgs e) //Open Reporting Pages
        {
            ReportingHome rh = new ReportingHome();
            rh.TopLevel = false;
            rh.AutoScroll = true;
            rh.FormBorderStyle = FormBorderStyle.None;
            rh.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();//Clear panelDisplay
            this.panelDisplay.Controls.Add(rh);
            rh.Show();
        }


        //Logout
        private void btnLogout_Click(object sender, EventArgs e) //Message for Logout
        {
            if(MessageBox.Show("Are you sure to Logout ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)  //Message for Close this Application
        {
            if(MessageBox.Show("Are you sure to close the Application ?","Confarmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                Close();
            }
            
        }

        private void ProductInfoLoad()
        {
            ProductInfo p = new ProductInfo();
            p.TopLevel = false;
            p.AutoScroll = true;
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();//Clear panelDisplay
            this.panelDisplay.Controls.Add(p);
            p.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e) //Open ProductInfo Page
        {
            ProductInfoLoad();   
        }

        private void btnCustomer_Click(object sender, EventArgs e) //Open CustomerInfo Page
        {
            CustomerInfo c = new CustomerInfo();
            c.TopLevel = false;
            c.AutoScroll = true;
            c.FormBorderStyle = FormBorderStyle.None;
            c.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(c);
            c.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e) //Open Settings Page
        {
            BillingSystem s = new BillingSystem();
          
            s.TopLevel = false;
            s.AutoScroll = true;
            s.FormBorderStyle = FormBorderStyle.None;
            s.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(s);
            s.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeInfo c = new EmployeeInfo();
            c.TopLevel = false;
            c.AutoScroll = true;
            c.FormBorderStyle = FormBorderStyle.None;
            c.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(c);
            c.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

            ProductInfoLoad();
        }
    }
}

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
    public partial class EmployeeHome : Form
    {
        public EmployeeHome()
        {
            InitializeComponent();
        }


        //Show Billing System When Employee click Home Button
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillingSystem bs = new BillingSystem();
            bs.TopLevel = false;
            bs.AutoScroll = true;
            bs.Dock = DockStyle.Fill;
            bs.FormBorderStyle = FormBorderStyle.None;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(bs);
            bs.Show();
        }

        //Show Billing System When Employee form is Loded
        private void EmployeeHome_Load(object sender, EventArgs e)
        {
            BillingSystem bs = new BillingSystem();
            bs.TopLevel = false;
            bs.AutoScroll = true;
            bs.Dock = DockStyle.Fill;
            bs.FormBorderStyle = FormBorderStyle.None;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(bs);
            bs.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure to Logout?","Confarmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
        }

        private void addCustomerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddCustomer ac = new AddCustomer();
            ac.TopLevel = false;
            ac.AutoScroll = true;
            ac.Dock = DockStyle.Fill;
            ac.FormBorderStyle = FormBorderStyle.None;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(ac);
            ac.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings s = new Settings();
            s.TopLevel = false;
            s.AutoScroll = true;
            s.Dock = DockStyle.Fill;
            s.FormBorderStyle = FormBorderStyle.None;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(s);
            s.Show();
        }

        private void customerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emp_CustomerInfo ci = new Emp_CustomerInfo();
            ci.TopLevel = false;
            ci.AutoScroll = true;
            ci.Dock = DockStyle.Fill;
            ci.FormBorderStyle = FormBorderStyle.None;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(ci);
            ci.Show();
        }
    }
}

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
    }
}

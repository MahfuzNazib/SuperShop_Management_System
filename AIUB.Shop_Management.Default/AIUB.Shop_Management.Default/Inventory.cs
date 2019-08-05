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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
        }

        private void tOOLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purches p = new Purches();
            p.Show();
            this.Hide();
        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductInfo pi = new ProductInfo();
            pi.Show();
            this.Hide();
        }

        private void bILLSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

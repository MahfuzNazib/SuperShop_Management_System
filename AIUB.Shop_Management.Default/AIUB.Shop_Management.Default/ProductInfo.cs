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
    public partial class ProductInfo : Form
    {
        public ProductInfo()
        {
            InitializeComponent();
            ShowChart();
        }

        private void ShowChart()
        {
            //this.chart1.Series["This Week"].Points.AddXY("Icecream", 28);
            //this.chart1.Series["This Week"].Points.AddXY("Biscit", 56);
            //this.chart1.Series["This Week"].Points.AddXY("Bevrage", 30);
            //this.chart1.Series["This Week"].Points.AddXY("Chips", 65);
            //this.chart1.Series["This Week"].Points.AddXY("Caned Food", 15);

            //this.chart1.Series["Last Week"].Points.AddXY("Icecream", 20);
            //this.chart1.Series["Last Week"].Points.AddXY("Biscit", 42);
            //this.chart1.Series["Last Week"].Points.AddXY("Bevrage", 50);
            //this.chart1.Series["Last Week"].Points.AddXY("Chips", 85);
            //this.chart1.Series["Last Week"].Points.AddXY("Caned Food", 5);
        }

        private void ShowInventory()
        {
            var inventory = new Inventory();
            inventory.Show();
            this.Hide();
        }

        private void ShowPurches()
        {
            var purches = new Purches();
            purches.Show();
            this.Hide();
        }

        private void ShowProductInfoPanel()
        {
            //this.panelDisplay.Controls.Clear();//Clear panelDisplay
            //this.panelDisplay.Controls.Add(this.tableLayoutPanel2);
            //this.panelDisplay.Controls.Add(this.btnCrtSellsLoad);
            //this.panelDisplay.Controls.Add(this.dataGridView1);
            //this.panelDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.panelDisplay.Location = new System.Drawing.Point(3, 34);
            //this.panelDisplay.Name = "panelDisplay";
            //this.panelDisplay.Size = new System.Drawing.Size(1178, 624);
            //this.panelDisplay.TabIndex = 4;
        }

        private void puerchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPurches();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Hide();
        }

        private void tOOLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory p = new Inventory();
            p.TopLevel = false;
            p.AutoScroll = true;
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();//Clear panelDisplay
            this.panelDisplay.Controls.Add(p);
            p.Show();
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purches p = new Purches();
            p.TopLevel = false;
            p.AutoScroll = true;
            p.FormBorderStyle = FormBorderStyle.None;
            p.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();//Clear panelDisplay
            this.panelDisplay.Controls.Add(p);
            p.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnCrtSellsLoad_Click(object sender, EventArgs e)
        {
            //this.crtSells.Series["Product1"].Points.AddXY("January", 634);
            //this.crtSells.Series["Product1"].Points.AddXY("February", 846);
            //this.crtSells.Series["Product1"].Points.AddXY("March", 334);
            //this.crtSells.Series["Product1"].Points.AddXY("April", 534);
            //this.crtSells.Series["Product1"].Points.AddXY("May", 365);
            //this.crtSells.Series["Product1"].Points.AddXY("June", 658);
            //this.crtSells.Series["Product1"].Points.AddXY("July", 654);
            //this.crtSells.Series["Product1"].Points.AddXY("August", 957);
            //this.crtSells.Series["Product1"].Points.AddXY("September", 128);
            //this.crtSells.Series["Product1"].Points.AddXY("October", 684);
            //this.crtSells.Series["Product1"].Points.AddXY("November", 842);
            //this.crtSells.Series["Product1"].Points.AddXY("December", 567);
        }

        private void aDMINToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowProductInfoPanel();
        }

        private void pRODUCTLISTSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList pl = new ProductList();
            pl.TopLevel = false;
            pl.AutoScroll = true;
            pl.FormBorderStyle = FormBorderStyle.None;
            pl.Dock = DockStyle.Fill;

            this.panelDisplay.Controls.Clear();
            this.panelDisplay.Controls.Add(pl);
            pl.Show();
        }
    }
}

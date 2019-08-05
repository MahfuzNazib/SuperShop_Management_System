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
    public partial class ReportingHome : Form
    {
        public ReportingHome()
        {
            InitializeComponent();
        }

        private void ReportingHome_Load(object sender, EventArgs e)
        {
            lblDateDisplay.Text = DateTime.Now.ToLongDateString();//Display Date
            lblTimeDisplay.Text = DateTime.Now.ToLongTimeString();//Display Time
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string getText = drpdwnSelectType.selectedValue; 

                //All Report from Database
                if(getText=="All")
                {
                    AllReport ar = new AllReport();
                    ar.TopLevel = false;
                    ar.AutoScroll = true;
                    ar.FormBorderStyle = FormBorderStyle.None;
                    ar.Dock = DockStyle.Fill;

                    this.panelDisplayReport.Controls.Clear();

                    this.panelDisplayReport.Controls.Add(ar);
                    ar.Show();
                }

                //Monthly/Custom Report
                else if(getText=="Monthly/Custom")
                {
                    CustomReport cr = new CustomReport();
                    cr.TopLevel = false;
                    cr.AutoScroll = true;
                    cr.FormBorderStyle = FormBorderStyle.None;
                    cr.Dock = DockStyle.Fill;

                    this.panelDisplayReport.Controls.Clear();
                    this.panelDisplayReport.Controls.Add(cr);
                    cr.Show();
                }

                //Daily Report
                else if (drpdwnSelectType.selectedValue == "Daily")
                {
                    DailyReport dr = new DailyReport();
                    dr.TopLevel = false;
                    dr.AutoScroll = true;
                    dr.FormBorderStyle = FormBorderStyle.None;
                    dr.Dock = DockStyle.Fill;

                    this.panelDisplayReport.Controls.Clear();

                    this.panelDisplayReport.Controls.Add(dr);
                    dr.Show();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Select Reporting Type First", "Error " + ex, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

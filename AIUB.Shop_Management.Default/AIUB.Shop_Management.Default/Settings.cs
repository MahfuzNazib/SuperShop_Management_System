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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void txtNewPass_TextChanged(object sender, EventArgs e)
        {
            if(txtNewPass.Text!=txtConfirmPass.Text)
            {
                lblError.Visible = true;
                return;
            }
            else
            {
                lblError.Visible = false;
            }
        }
    }
}

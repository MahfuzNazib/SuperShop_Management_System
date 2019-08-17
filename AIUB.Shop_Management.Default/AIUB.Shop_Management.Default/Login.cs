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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
           
        }
        private void PageLoad()
        {
            string query = "select * from Employee where EmpId='" + txtUsername.Text + "' and [Password]='" + txtPassword.Text + "'";
            DataTable dt = DBConnection.GetDataTable(query);
            if (dt.Rows.Count != 1)
            {
                lblError.Visible = true;
                return;
            }
            else
            {
                lblError.Visible = false;
                string status = dt.Rows[0]["Status"].ToString();
                if (status == "1")
                {
                    Admin a = new Admin();
                    a.Show();
                    this.Hide();
                }
                else if (status == "2")
                {
                    EmployeeHome eh = new EmployeeHome();
                    eh.Show();
                    this.Hide();
                }
                else
                    lblError.Visible = true;

            }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            PageLoad();

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter) //press enter to go to the password
            {
                txtPassword.Focus(); 
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                PageLoad();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuImageButton1_MouseHover(object sender, EventArgs e)
        {
            bunifuImageButton1.BackColor = Color.Red;
        }

        private void bunifuImageButton1_MouseLeave(object sender, EventArgs e)
        {
            bunifuImageButton1.BackColor = Color.LightBlue;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSwitch1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}

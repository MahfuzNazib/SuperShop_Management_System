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
using iTextSharp.text; //for ItextSharp
using iTextSharp.text.pdf; //for ItextSharp ->> PDF
using System.IO; //for Input and Output

namespace AIUB.Shop_Management.Default
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        private void txtEmpty()
        {
            txtSearch.text = txtId.Text = txtName.Text = txtContact.Text = txtSalary.Text = txtDasignation.Text = txtJDate.Text = txtPassword.Text = txtStatus.Text = "";
        }

        private void Checking()
        {
            if (txtName.Text=="")
            {
                MessageBox.Show("Name Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            else if(txtContact.Text=="")
            {
                MessageBox.Show("Contact Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            else if (txtDasignation.Text == "")
            {
                MessageBox.Show("Designation Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            else if (txtSalary.Text == "")
            {
                MessageBox.Show("Salary Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            else if (txtJDate.Text == "")
            {
                MessageBox.Show("Joining Date Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Password Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
               
            else if (txtStatus.Text == "")
            {
                MessageBox.Show("Status Must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
        }

        private void LoadDetails()
        {
            try
            {
                string query = "select * from Employee";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvEmpInfo.DataSource = dt;
                dgvEmpInfo.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void EmployeeInfo_Load(object sender, EventArgs e)
        {
            LoadDetails();
        }

        public void Search()
        {
            try
            {
                string query = "select * from Employee where EmpId='" + txtSearch.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvEmpInfo.DataSource = dt;
                dgvEmpInfo.Refresh();

                if (dt.Rows.Count == 1)
                {
                    txtId.Text = dt.Rows[0]["EmpId"].ToString();
                    txtName.Text = dt.Rows[0]["EmpName"].ToString();
                    txtContact.Text = dt.Rows[0]["EmpContact"].ToString();
                    txtDasignation.Text = dt.Rows[0]["Designation"].ToString();
                    txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                    txtJDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtStatus.Text = dt.Rows[0]["Status"].ToString();

                }

                else
                {
                    MessageBox.Show("Invalid Employee ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDetails();
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnAdd.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
            txtEmpty();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string query = "insert into Employee(EmpName,EmpContact,Designation,Salary,JoiningDate,[Password],[Status]) "
                + "values ('" + txtName.Text + "','" + txtContact.Text + "','" + txtDasignation.Text + "','" + txtSalary.Text + "','" + txtJDate.Text + "','" + txtPassword.Text + "','" + txtStatus.Text + "')";
            Checking();
            DBConnection.ExecuteQuery(query);
            MessageBox.Show("Successfully Added", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDetails();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(txtId.Text=="")
            {
                MessageBox.Show("Invalid ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = "update Employee set EmpName='"+txtName.Text+"',EmpContact='"+txtContact.Text+"',Designation='"+txtDasignation.Text+"',"
                +"Salary='"+txtSalary.Text+"',JoiningDate='"+txtJDate.Text+"',[Password]='"+txtPassword.Text+"',[Status]='"+txtStatus.Text+"' where EmpId='"+txtId.Text+"'";
            DBConnection.ExecuteQuery(query);
            MessageBox.Show("Successfully Updated", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Invalid ID ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = "delete from Employee where EmpId='"+txtId.Text+"'";
            if (MessageBox.Show("Are you Sure to Delete this Employee Data ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            DBConnection.ExecuteQuery(query);
            LoadDetails();
        }

        private void dgvEmpInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvEmpInfo.Rows[e.RowIndex].Cells[0].Value.ToString();
                try
                {
                    string query = "select * from Employee where EmpId=" + id;
                    DataTable dt = DBConnection.GetDataTable(query);
                 
                    if (dt.Rows.Count == 1)
                    {
                        txtId.Text = dt.Rows[0]["EmpId"].ToString();
                        txtName.Text = dt.Rows[0]["EmpName"].ToString();
                        txtContact.Text = dt.Rows[0]["EmpContact"].ToString();
                        txtDasignation.Text = dt.Rows[0]["Designation"].ToString();
                        txtSalary.Text = dt.Rows[0]["Salary"].ToString();
                        txtJDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                        txtPassword.Text = dt.Rows[0]["Password"].ToString();
                        txtStatus.Text = dt.Rows[0]["Status"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            btnAdd.Visible = btnUpdate.Visible = btnDelete.Visible = true;
            btnSave.Visible = false;
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void exportPdf(DataGridView dgv, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgv.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //adding header

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            //add data row

            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            exportPdf(dgvEmpInfo, "Employee_List");
        }

        private void txtDasignation_OnValueChanged(object sender, EventArgs e)
        {
            if (txtDasignation.Text == "Admin" || txtDasignation.Text == "admin" || txtDasignation.Text == "ADMIN")
                txtStatus.Text = "1";
            else if (txtDasignation.Text == "SellsMen" || txtDasignation.Text == "Manager")
                txtStatus.Text = "2";
        }

    }
}

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
    public partial class CustomerInfo : Form
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }
        public void ButtonControl()
        {
            btnSave.Visible = false;
            txtCustomerId.ReadOnly = false;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
        }

        public void LoadDetails()
        {
            try
            {
                string query = "select * from Customer";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvCustomerInfo.DataSource = dt;
                dgvCustomerInfo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {
            
            LoadDetails();
            ButtonControl();
        }

        public void Search()
        {
            try
            {
                string query = "select * from Customer where CustomerId='" + txtSearch.text + "'";
                DataTable dt = DBConnection.GetDataTable(query);
                dgvCustomerInfo.DataSource = dt;
                dgvCustomerInfo.Refresh();

                if (dt.Rows.Count == 1)
                {
                    txtCustomerId.Text = dt.Rows[0]["CustomerId"].ToString();
                    txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                    txtCustomerContact.Text = dt.Rows[0]["Contact"].ToString();
                    dtpJoiningDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                    txtTotalPoint.Text = dt.Rows[0]["Point"].ToString();

                }

                else
                {
                    MessageBox.Show("Invalid Customer ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ButtonControl();
        }

        private void dgvCustomerInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            ButtonControl();
            if(e.RowIndex>=0)
            {
                string id = dgvCustomerInfo.Rows[e.RowIndex].Cells[0].Value.ToString();

                try
                {
                    string query = "select * from Customer where CustomerId="+id;
                    DataTable dt = DBConnection.GetDataTable(query);

                    if (dt.Rows.Count == 1)
                    {
                        txtCustomerId.Text = dt.Rows[0]["CustomerId"].ToString();
                        txtCustomerName.Text = dt.Rows[0]["CustomerName"].ToString();
                        txtCustomerContact.Text = dt.Rows[0]["Contact"].ToString();
                        dtpJoiningDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                        txtTotalPoint.Text = dt.Rows[0]["Point"].ToString();

                    }

                    else
                    {
                        MessageBox.Show("Invalid Customer ID", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnUpdate.Visible = false;
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Text=txtCustomerName.Text = txtCustomerContact.Text = txtTotalPoint.Text = txtSearch.text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtCustomerId.Text = txtCustomerContact.Text;
            string query = "insert into Customer(CustomerId,CustomerName,Contact,JoiningDate,Point) "
                +"values('"+txtCustomerId.Text+"','"+txtCustomerName.Text+"','"+txtCustomerContact.Text+"','"+dtpJoiningDate.Text+"','"+txtTotalPoint.Text+"')";
            DBConnection.ExecuteQuery(query);
            MessageBox.Show("New Customer Added Done", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDetails();
        }

        private void txtCustomerContact_TextChanged(object sender, EventArgs e)
        {
            txtCustomerId.Text = txtCustomerContact.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "Update Customer set CustomerName='"+txtCustomerName.Text+"',Contact='"+txtCustomerContact.Text+"',"
                +"JoiningDate='"+dtpJoiningDate.Text+"',Point='"+txtTotalPoint.Text+"' where CustomerId='"+txtCustomerId.Text+"'";
            DBConnection.ExecuteQuery(query);
            MessageBox.Show("Successfully Updated", "Updation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDetails();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "delete from Customer where CustomerId='"+txtCustomerId.Text+"'";
            if(MessageBox.Show("Are you sure to Delete this Customer","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                DBConnection.ExecuteQuery(query);
                MessageBox.Show("Successfully Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDetails();
            }
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            exportPdf(dgvCustomerInfo, "Customer_List");
        }
    }
}

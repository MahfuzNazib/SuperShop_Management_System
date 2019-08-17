using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text; //for ItextSharp
using iTextSharp.text.pdf; //for ItextSharp ->> PDF
using System.IO; //for Input and Output

namespace AIUB.Shop_Management.Default
{
    public partial class CustomReport : Form
    {
        public CustomReport()
        {
            InitializeComponent();
        }

        private void CustomReport_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string query = "select * from Sells where SellsDate between '"+dtpFrom.Text+"' and '"+dtpTo.Text+"'";
            DataTable dt = DBConnection.GetDataTable(query);
            dgvCustomReport.DataSource = dt;
            dgvCustomReport.Refresh();

            //for cost Finding

            string querycost = "select sum(NetAmount) as amount from Sells where SellsDate between '"+dtpFrom.Text+"' and '"+dtpTo.Text+"'";
            DataTable dtcost = DBConnection.GetDataTable(querycost);

            if (dtcost.Rows.Count == 1)
            {
                txtTotalSells.Text = dtcost.Rows[0]["amount"].ToString();
            }

            //investment sum

            string queryinvest = "select sum(TotalCost) as amount from Product where PurchaseDate between '"+dtpFrom.Text+"' and '"+dtpTo.Text+"'";
            DataTable dtinvest = DBConnection.GetDataTable(queryinvest);

            if (dtinvest.Rows.Count == 1)
            {
                txtInvestment.Text = dtinvest.Rows[0]["amount"].ToString();
            }
        }

        private void txtInvestment_TextChanged(object sender, EventArgs e)
        {
            

            if (txtInvestment.Text != "" || txtTotalSells.Text != "")
            {
                try
                {

                    double sells = Convert.ToDouble(txtTotalSells.Text);
                    double investment = Convert.ToDouble(txtInvestment.Text);

                    if (sells > investment)
                    {
                        lblProfit.Visible = true;

                        double amt = sells - investment;
                        lblPAmount.Text = amt.ToString();
                        lblTaka.Visible = true;
                        lblPAmount.Visible = true;
                    }

                    else if (sells < investment)
                    {
                        lblProfit.Visible = false;
                        lblLoss.Visible = true;
                        double amt = sells - investment;
                        lblPAmount.Text = amt.ToString();
                        lblPAmount.Visible = true;
                        lblTaka.Visible = true;
                        if (lblLoss.Visible == true)
                        {
                            lblPAmount.ForeColor = Color.Red;
                            lblTaka.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        //nothing to do;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            exportPdf(dgvCustomReport, "Custom Report List");
        }
    }
}

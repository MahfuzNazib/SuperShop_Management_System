namespace AIUB.Shop_Management.Default
{
    partial class ReportingHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportingHome));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.drpdwnSelectType = new Bunifu.Framework.UI.BunifuDropdown();
            this.lblTimeDisplay = new System.Windows.Forms.Label();
            this.lblDateDisplay = new System.Windows.Forms.Label();
            this.btnLoad = new Bunifu.Framework.UI.BunifuThinButton2();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDisplayReport = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.743633F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.28014F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.470289F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.66214F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.00679F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.75212F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.drpdwnSelectType, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLoad, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblTimeDisplay, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDateDisplay, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1178, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Type";
            // 
            // drpdwnSelectType
            // 
            this.drpdwnSelectType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.drpdwnSelectType.BackColor = System.Drawing.Color.Transparent;
            this.drpdwnSelectType.BorderRadius = 3;
            this.drpdwnSelectType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drpdwnSelectType.DisabledColor = System.Drawing.Color.Gray;
            this.drpdwnSelectType.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpdwnSelectType.ForeColor = System.Drawing.Color.Black;
            this.drpdwnSelectType.Items = new string[] {
        "All",
        "Daily",
        "Monthly/Custom"};
            this.drpdwnSelectType.Location = new System.Drawing.Point(107, 7);
            this.drpdwnSelectType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.drpdwnSelectType.Name = "drpdwnSelectType";
            this.drpdwnSelectType.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.drpdwnSelectType.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.drpdwnSelectType.selectedIndex = -1;
            this.drpdwnSelectType.Size = new System.Drawing.Size(172, 33);
            this.drpdwnSelectType.TabIndex = 2;
            // 
            // lblTimeDisplay
            // 
            this.lblTimeDisplay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTimeDisplay.AutoSize = true;
            this.lblTimeDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeDisplay.Location = new System.Drawing.Point(1123, 13);
            this.lblTimeDisplay.Name = "lblTimeDisplay";
            this.lblTimeDisplay.Size = new System.Drawing.Size(52, 21);
            this.lblTimeDisplay.TabIndex = 4;
            this.lblTimeDisplay.Text = "label2";
            // 
            // lblDateDisplay
            // 
            this.lblDateDisplay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDateDisplay.AutoSize = true;
            this.lblDateDisplay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDisplay.Location = new System.Drawing.Point(960, 13);
            this.lblDateDisplay.Name = "lblDateDisplay";
            this.lblDateDisplay.Size = new System.Drawing.Size(52, 21);
            this.lblDateDisplay.TabIndex = 5;
            this.lblDateDisplay.Text = "label2";
            // 
            // btnLoad
            // 
            this.btnLoad.ActiveBorderThickness = 1;
            this.btnLoad.ActiveCornerRadius = 5;
            this.btnLoad.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnLoad.ActiveForecolor = System.Drawing.Color.White;
            this.btnLoad.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoad.BackgroundImage")));
            this.btnLoad.ButtonText = "&Load";
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnLoad.IdleBorderThickness = 1;
            this.btnLoad.IdleCornerRadius = 5;
            this.btnLoad.IdleFillColor = System.Drawing.Color.White;
            this.btnLoad.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnLoad.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnLoad.Location = new System.Drawing.Point(288, 5);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(78, 38);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDisplayReport, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.320726F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.67928F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 661);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panelDisplayReport
            // 
            this.panelDisplayReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDisplayReport.Location = new System.Drawing.Point(3, 57);
            this.panelDisplayReport.Name = "panelDisplayReport";
            this.panelDisplayReport.Size = new System.Drawing.Size(1178, 601);
            this.panelDisplayReport.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(547, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reporting Page";
            // 
            // ReportingHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReportingHome";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ReportingHome_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuDropdown drpdwnSelectType;
        private Bunifu.Framework.UI.BunifuThinButton2 btnLoad;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTimeDisplay;
        private System.Windows.Forms.Label lblDateDisplay;
        private System.Windows.Forms.Panel panelDisplayReport;
        private System.Windows.Forms.Label label2;
    }
}
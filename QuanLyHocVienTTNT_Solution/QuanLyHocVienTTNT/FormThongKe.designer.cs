namespace QuanLyHocVienTTNT
{
    partial class FormThongKe
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
            this.BT_DanhSachHV = new System.Windows.Forms.Button();
            this.Cbo_MaHP = new System.Windows.Forms.ComboBox();
            this.LB_MaHP = new System.Windows.Forms.Label();
            this.BT_DoanhThu = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_DanhSachHV
            // 
            this.BT_DanhSachHV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BT_DanhSachHV.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_DanhSachHV.Location = new System.Drawing.Point(193, 73);
            this.BT_DanhSachHV.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BT_DanhSachHV.Name = "BT_DanhSachHV";
            this.BT_DanhSachHV.Size = new System.Drawing.Size(292, 40);
            this.BT_DanhSachHV.TabIndex = 0;
            this.BT_DanhSachHV.Text = "Danh sách học viên";
            this.BT_DanhSachHV.UseVisualStyleBackColor = true;
            this.BT_DanhSachHV.Click += new System.EventHandler(this.BT_DanhSachHV_Click);
            // 
            // Cbo_MaHP
            // 
            this.Cbo_MaHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Cbo_MaHP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_MaHP.FormattingEnabled = true;
            this.Cbo_MaHP.Location = new System.Drawing.Point(441, 145);
            this.Cbo_MaHP.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Cbo_MaHP.Name = "Cbo_MaHP";
            this.Cbo_MaHP.Size = new System.Drawing.Size(432, 32);
            this.Cbo_MaHP.TabIndex = 1;
            this.Cbo_MaHP.SelectedIndexChanged += new System.EventHandler(this.Cbo_MaHP_SelectedIndexChanged);
            // 
            // LB_MaHP
            // 
            this.LB_MaHP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LB_MaHP.AutoSize = true;
            this.LB_MaHP.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_MaHP.ForeColor = System.Drawing.Color.MediumBlue;
            this.LB_MaHP.Location = new System.Drawing.Point(227, 151);
            this.LB_MaHP.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.LB_MaHP.Name = "LB_MaHP";
            this.LB_MaHP.Size = new System.Drawing.Size(126, 24);
            this.LB_MaHP.TabIndex = 2;
            this.LB_MaHP.Text = "Mã Học Phần";
            // 
            // BT_DoanhThu
            // 
            this.BT_DoanhThu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BT_DoanhThu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_DoanhThu.Location = new System.Drawing.Point(567, 73);
            this.BT_DoanhThu.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BT_DoanhThu.Name = "BT_DoanhThu";
            this.BT_DoanhThu.Size = new System.Drawing.Size(306, 40);
            this.BT_DoanhThu.TabIndex = 3;
            this.BT_DoanhThu.Text = "Doanh Thu Theo Lớp";
            this.BT_DoanhThu.UseVisualStyleBackColor = true;
            this.BT_DoanhThu.Click += new System.EventHandler(this.BT_DoanhThu_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.AutoSize = true;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crystalReportViewer1.Location = new System.Drawing.Point(7, 206);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1028, 578);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ToolPanelWidth = 100;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(435, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "THỐNG KÊ";
            // 
            // FormThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 697);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.BT_DoanhThu);
            this.Controls.Add(this.LB_MaHP);
            this.Controls.Add(this.Cbo_MaHP);
            this.Controls.Add(this.BT_DanhSachHV);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormThongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.FormThongKe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_DanhSachHV;
        private System.Windows.Forms.ComboBox Cbo_MaHP;
        private System.Windows.Forms.Label LB_MaHP;
        private System.Windows.Forms.Button BT_DoanhThu;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
    }
}
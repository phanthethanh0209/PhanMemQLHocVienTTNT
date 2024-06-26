namespace QuanLyHocVienTTNT
{
    partial class FormDangNhap
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
            this.link_DoiMK = new System.Windows.Forms.LinkLabel();
            this.btn_ThoatDN = new System.Windows.Forms.Button();
            this.btn_DangNhap = new System.Windows.Forms.Button();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // link_DoiMK
            // 
            this.link_DoiMK.AutoSize = true;
            this.link_DoiMK.BackColor = System.Drawing.Color.Transparent;
            this.link_DoiMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.link_DoiMK.Location = new System.Drawing.Point(530, 574);
            this.link_DoiMK.Name = "link_DoiMK";
            this.link_DoiMK.Size = new System.Drawing.Size(150, 25);
            this.link_DoiMK.TabIndex = 19;
            this.link_DoiMK.TabStop = true;
            this.link_DoiMK.Text = "Đổi mật khẩu?";
            this.link_DoiMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_DoiMK_LinkClicked);
            // 
            // btn_ThoatDN
            // 
            this.btn_ThoatDN.AutoSize = true;
            this.btn_ThoatDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ThoatDN.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_ThoatDN.Location = new System.Drawing.Point(535, 517);
            this.btn_ThoatDN.Name = "btn_ThoatDN";
            this.btn_ThoatDN.Size = new System.Drawing.Size(139, 39);
            this.btn_ThoatDN.TabIndex = 18;
            this.btn_ThoatDN.Text = "Thoát";
            this.btn_ThoatDN.UseVisualStyleBackColor = true;
            this.btn_ThoatDN.Click += new System.EventHandler(this.btn_ThoatDN_Click);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.AutoSize = true;
            this.btn_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DangNhap.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_DangNhap.Location = new System.Drawing.Point(323, 517);
            this.btn_DangNhap.Name = "btn_DangNhap";
            this.btn_DangNhap.Size = new System.Drawing.Size(139, 39);
            this.btn_DangNhap.TabIndex = 17;
            this.btn_DangNhap.Text = "Đăng nhập";
            this.btn_DangNhap.UseVisualStyleBackColor = true;
            this.btn_DangNhap.Click += new System.EventHandler(this.btn_DangNhap_Click);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.ForeColor = System.Drawing.Color.Salmon;
            this.txt_password.Location = new System.Drawing.Point(398, 458);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(276, 34);
            this.txt_password.TabIndex = 16;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // txt_username
            // 
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_username.ForeColor = System.Drawing.Color.Salmon;
            this.txt_username.Location = new System.Drawing.Point(398, 402);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(276, 34);
            this.txt_username.TabIndex = 13;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::QuanLyHocVienTTNT.Properties.Resources.icon_pass;
            this.pictureBox3.Location = new System.Drawing.Point(323, 449);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 51);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::QuanLyHocVienTTNT.Properties.Resources.user_97890_1280;
            this.pictureBox2.Location = new System.Drawing.Point(323, 392);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::QuanLyHocVienTTNT.Properties.Resources.user_icons;
            this.pictureBox1.Location = new System.Drawing.Point(427, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // FormDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::QuanLyHocVienTTNT.Properties.Resources.ABC2__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1039, 631);
            this.Controls.Add(this.link_DoiMK);
            this.Controls.Add(this.btn_ThoatDN);
            this.Controls.Add(this.btn_DangNhap);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDangNhap";
            this.Text = "FormDangNhap";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDangNhap_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel link_DoiMK;
        private System.Windows.Forms.Button btn_ThoatDN;
        private System.Windows.Forms.Button btn_DangNhap;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
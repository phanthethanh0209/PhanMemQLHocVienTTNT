using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocVienTTNT
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = btn_DangNhap;
        }

        DBConnect db = new DBConnect();

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string tentk = txt_username.Text;
            string matkhau = txt_password.Text;

            string chuoitruyvan = "Select * from NHANVIEN where TENTKNV = '" + tentk + "' and MATKHAU = '" + matkhau + "'";
            DataTable dt_nv = db.getDataTable(chuoitruyvan);

            string chuoitv = "Select * from GIAOVIEN where TENTKGV = '" + tentk + "' and MATKHAU = '" + matkhau + "'";
            DataTable dt_gv = db.getDataTable(chuoitv);

            if (!Function.checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản bao gồm 6 kí tự trở lên, có cả chữ và số!", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txt_username.Focus();
            }
            else if (!Function.checkPass(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu theo đúng định dạng\nLưu ý mật khẩu bao gồm 8 kí tự trở lên, có chữ cái viết Hoa, có chữ số và kí tự đặc biệt",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txt_password.Focus();
            }
            else if (dt_nv.Rows.Count != 0)
            {
                FormChinh.loaitk = "Nhân viên";
                FormChinh.tentk = dt_nv.Rows[0]["TENTKNV"].ToString();
                MessageBox.Show("Đăng nhập thành công ! Xin chào Admin 💟", "Thành công",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Hide();
                FormChinh frmChinh = new FormChinh();
                frmChinh.ShowDialog();
                this.FormClosing -= FormDangNhap_FormClosing;
                this.Close();
            }
            else if (dt_gv.Rows.Count != 0)
            {
                FormChinh.loaitk = "Giáo viên";
                //FormChinh.tentk = dt_gv.Rows[0]["TENTKGV"].ToString();
                FormChinh.magv = dt_gv.Rows[0]["MAGV"].ToString();
                MessageBox.Show("Đăng nhập thành công !\nXin chào thầy/cô " + dt_gv.Rows[0]["TENGV"].ToString() + " 🥰\nChúc thầy/cô một ngày tốt lành 💕", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Hide();
                FormChinh frmChinh = new FormChinh();
                frmChinh.ShowDialog();
                this.FormClosing -= FormDangNhap_FormClosing;
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại! Vui lòng kiểm tra lại thông tin", "Thất bại", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }


        private void link_DoiMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDoiMK frmdmk = new FormDoiMK();
            frmdmk.ShowDialog();
            this.FormClosing -= FormDangNhap_FormClosing;
            this.Close();
        }

        private void btn_ThoatDN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}

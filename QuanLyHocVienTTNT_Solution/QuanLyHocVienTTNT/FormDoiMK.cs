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
    public partial class FormDoiMK : Form
    {
        public FormDoiMK()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AcceptButton = btn_DoiMK;

        }

        DBConnect db = new DBConnect();

        private void btn_DoiMK_Click(object sender, EventArgs e)
        {
            string tentk = txt_username.Text;
            string matkhau = txt_password.Text;
            string matkhaumoi = txt_newpass.Text;
            string xacnhanmk = txt_confirm.Text;

            string chuoitruyvan = "Select * from NHANVIEN where TENTKNV = '" + tentk + "' and MATKHAU = '" + matkhau + "'";
            DataTable dt_nv = db.getDataTable(chuoitruyvan);

            string chuoitv = "Select * from GIAOVIEN where TENTKGV = '" + tentk + "' and MATKHAU = '" + matkhau + "'";
            DataTable dt_gv = db.getDataTable(chuoitv);

            if (!Function.checkAccount(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản bao gồm 6 kí tự trở lên, có cả chữ và số! ", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txt_username.Focus();
            }
            else if (!Function.checkPass(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu theo đúng định dạng\nLưu ý mật khẩu bao gồm 8 kí tự trở lên, có chữ cái viết Hoa, có chữ số và kí tự đặc biệt",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txt_password.Focus();
            }
            else if (!Function.checkPass(matkhaumoi))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới theo đúng định dạng\nLưu ý mật khẩu bao gồm 8 kí tự trở lên, có chữ cái viết Hoa, có chữ số và kí tự đặc biệt",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txt_newpass.Focus();
            }
            else if (!xacnhanmk.Equals(matkhaumoi))
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp! Vui lòng nhập lại","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                txt_confirm.Focus();
            }
            else if (dt_nv.Rows.Count != 0)
            {
                string tv = "update NHANVIEN set MATKHAU = '" + matkhaumoi + "' where TENTKNV = '" + tentk + "'";
                int kq = db.getNonQuery(tv);
                if (kq > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công !\nHãy nhấn thoát để quay lại đăng nhập nhé 💝", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else if (dt_gv.Rows.Count != 0)
            {
                string tv = "update GIAOVIEN set MATKHAU = '" + matkhaumoi + "' where TENTKGV = '" + tentk + "'";
                int kq = db.getNonQuery(tv);
                if (kq > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công !\nHãy nhấn thoát để quay lại đăng nhập nhé 💝","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại! Vui lòng kiểm tra lại thông tin","Lỗi", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void FormDoiMK_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn chắc chắn muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap frm = new FormDangNhap();
            frm.ShowDialog();
            this.FormClosing -= FormDoiMK_FormClosing;
            this.Close();
        }
    }
}

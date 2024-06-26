using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//=========================NỘI DUNG====
//// Kiểm tra tên GV không được là số
//// Kiểm phải nhập đủ thông tin mới xác nhận thành công

namespace QuanLyHocVienTTNT
{
    public partial class FormNhapGV : Form
    {
        DBConnect db = new DBConnect();
        public FormNhapGV()
        {
            InitializeComponent();
        }

        private void FormNhapGV_Load(object sender, EventArgs e)
        {
            txt_MaGV.Text = Function.TaoMa("GV", "Select TOP 1 MaGV from GIAOVIEN WHERE MaGV LIKE 'GV%' ORDER BY MaGV DESC");
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            //kiểm tra đã nhập đủ thông tin chưa
            if (txt_TenGV.Text == "" || txt_TenTK.Text == "" || txt_MatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            string chuoitruyvan = "Insert into GIAOVIEN values('" + txt_MaGV.Text + "',N'" + txt_TenGV.Text + "','" + txt_TenTK.Text + "','" + txt_MatKhau.Text + "')";
            int k = db.getNonQuery(chuoitruyvan);
            if (k == 1)
            {
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
 
        }

        private void txt_TenGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                this.errorProvider1.SetError(txt_TenGV, "Không nhập kí tự số!");
                e.Handled = true;
            }
            else
                this.errorProvider1.Clear();
        }

        private void txt_TenTK_TextChanged(object sender, EventArgs e)
        {
            if (Function.checkAccount(txt_TenTK.Text) == false)
            {
                this.errorProvider1.SetError(txt_TenTK, "Tên tài khoản phải từ 6 kí tự trở lên và nhỏ hơn 24 kí tự!");
            }
            else
                this.errorProvider1.Clear();
        }

        private void txt_MatKhau_TextChanged(object sender, EventArgs e)
        {
            if (Function.checkPass(txt_MatKhau.Text) == false)
            {
                this.errorProvider1.SetError(txt_MatKhau, "Mật khẩu phải từ 8 kí tự trở lên, 1 kí tự hoa, 1 kí tự số và 1 kí tự đặc biệt!");
            }
            else
                this.errorProvider1.Clear();
        }



    }
}
